using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using NHN.DtoContracts.Flr.Service;
using NHN.DtoContracts.Logging.Service;
using NHN.DtoContracts.Ofr.Service;
using NHN.DtoContracts.ServiceBus.Service;
using NHN.DtoContracts.ServiceBusConnector.Service;

namespace NHN.WcfClientFactory
{
    /// <summary>
    /// Factory for å opprette WCF service proxy klasser. Ingen XML-konfigurasjon nødvendig!
    /// </summary>
    /// <example>
    /// Eksempel på bruk:
    /// <code>
    /// <![CDATA[
    /// var clientFactory = new WcfClientFactory(Hostnames.Utvikling) { Username = "USERNAME", Password = "PASSWORD", Transport = Transport.Https };
    /// var flrRead = clientFactory.Get<IFlrReadOperations>();
    /// var flrWrite = clientFactory.Get<IFlrWriteOperations>();
    /// ...
    /// var clientFactory2 = clientFactory.Clone();
    /// clientFactory2.Transport = Transport.NetTcp;
    /// var flrExport = clientFactory2.Get<IFlrExportOperations>();
    /// ...
    /// ]]>
    /// </code>
    /// </example>
    public class WcfClientFactory
    {
        private bool _locked;

        private string _hostname;
        /// <summary>
        /// Hostname til endpoint.
        /// </summary>
        public string Hostname
        {
            get { return _hostname; }
            set
            {
                EnsureNotLocked();
                _hostname = value;
            }
        }

        private string _username;
        /// <summary>
        /// Brukernavn.
        /// </summary>
        public string Username
        {
            get { return _username; }
            set
            {
                EnsureNotLocked();
                _username = value;
            }
        }

        private string _password;
        /// <summary>
        /// Passord.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                EnsureNotLocked();
                _password = value;
            }
        }

        private Transport _transport;
        /// <summary>
        /// Transport. Enten https eller tcp.
        /// </summary>
        public Transport Transport
        {
            get { return _transport; }
            set
            {
                EnsureNotLocked();
                _transport = value;
            }
        }

        private string _proxyAddress;
        /// <summary>
        /// Proxyadresse (kun for https transport).
        /// </summary>
        /// <remarks>
        /// Verdien satt her vil gjelde foran systemets proxyinstillinger.
        /// Settes null eksplisitt, vil systemets proxyinstillinger ikke brukes.
        /// </remarks>
        public string ProxyAddress
        {
            get { return _proxyAddress; }
            set
            {
                EnsureNotLocked();
                _proxyAddress = value;
                UseDefaultWebProxy = false;
            }
        }

        private int? _port;
        /// <summary>
        /// Portnummer for endpoint.
        /// </summary>
        public int? Port
        {
            get { return _port; }
            set
            {
                EnsureNotLocked();
                _port = value;
            }
        }

        private bool _useDefaultWebProxy;
        /// <summary>
        /// Hvorvidt bruke systemets proxyinstillinger. Hvis <see cref="ProxyAddress"/> er satt, blir denne
        /// verdien ignorert.
        ///
        /// Default: true.
        /// </summary>
        public bool UseDefaultWebProxy
        {
            get { return _useDefaultWebProxy; }
            set
            {
                EnsureNotLocked();
                _useDefaultWebProxy = value;
            }
        }

        /// <summary>
        /// If you get the exception System.ServiceModel.Security.MessageSecurityException: The Identity check failed for the outgoing message. We enable this by default.
        /// http://stackoverflow.com/questions/34910373/wcf-sslstreamsecurity-dns-identity-check-failing-for-just-4-6-framework
        /// </summary>
        public bool FixDnsIdentityProblem { get; set; }

        private readonly Dictionary<string, ServiceContractConfig> _serviceContractConfigs = new Dictionary<string, ServiceContractConfig>();
        private readonly Dictionary<Type, ChannelFactory> _channelFactories = new Dictionary<Type, ChannelFactory>();
        private readonly object _syncRoot = new object();

        /// <summary>
        /// Oppretter et nytt WcfClientFactory.
        /// </summary>
        /// <param name="hostname">Hostname til endpoint.</param>
        public WcfClientFactory(string hostname)
        {
            _hostname = hostname;

            UseDefaultWebProxy = true;

            AddDefaultServiceContractsConfig();
        }

        private void AddDefaultServiceContractsConfig()
        {
            AddKnownConfig<IFlrReadOperations>(new ServiceContractConfig("/v2/flr"));
            AddKnownConfig<IFlrWriteOperations>(new ServiceContractConfig("/v2/flrwrite"));
            AddKnownConfig<IFlrExportOperations>(new ServiceContractConfig("/v2/flrexport")
            {
                TransferMode = TransferMode.StreamedResponse,
                ReceiveTimeout = TimeSpan.FromMinutes(70),
                SendTimeout = TimeSpan.FromMinutes(70)
            });
            AddKnownConfig<IServiceBusManagerV2>(new ServiceContractConfig("/v2/servicebusmanager"));
            AddKnownConfig<IServicebusService>(new ServiceContractConfig("/v1/ServiceBusService"));
            AddKnownConfig<ILogFetchingService>(new ServiceContractConfig("/v1/LogFetching"));
            AddKnownConfig<IOfrService>(new ServiceContractConfig("/v1/ofr"));
        }

        /// <summary>
        /// Legger til WCF konfigurasjon for en servicekontrakt.
        /// </summary>
        /// <typeparam name="T">Typen til servicekontrakten.</typeparam>
        /// <param name="config">Config-objekt som inneholder WCF-instillinger som skal gjelde for servicekontrakten.</param>
        public void AddKnownConfig<T>(ServiceContractConfig config)
        {
            AddKnownConfig(typeof(T).Name, config);
        }

        /// <summary>
        /// Legger til WCF konfigurasjon for en servicekontrakt.
        /// </summary>
        /// <param name="nameOfType">Navn på typen til servicekontrakten.</param>
        /// <param name="config">Config-objekt som inneholder WCF-instillinger som skal gjelde for servicekontrakten.</param>
        public void AddKnownConfig(string nameOfType, ServiceContractConfig config)
        {
            _serviceContractConfigs.Add(nameOfType, config);
        }

        /// <summary>
        /// Henter en servicekontrakt proxy, ferdig konfigurert.
        /// </summary>
        /// <param name="pathOverride">Overstyr pathen for denne servicekontrakten.</param>
        /// <typeparam name="T">Typen til servicekontrakten.</typeparam>
        /// <returns></returns>
        public T Get<T>(string pathOverride = null)
        {
            if (FixDnsIdentityProblem) AppContext.SetSwitch("Switch.System.IdentityModel.DisableMultipleDNSEntriesInSANCertificate", true);

            _locked = true;
            var serviceContractType = typeof (T);

            ChannelFactory<T> channelFactory;

            lock (_syncRoot)
            {
                if (_channelFactories.ContainsKey(serviceContractType))
                {
                    channelFactory = (ChannelFactory<T>) _channelFactories[serviceContractType];
                }
                else
                {
                    var config = GetServiceContractConfig(serviceContractType);
                    var binding = CreateBinding(config);
                    var endpointAddress = GetEndpointAddress<T>(pathOverride);

                    channelFactory = new ChannelFactory<T>(binding, new EndpointAddress(endpointAddress));
                    _channelFactories[serviceContractType] = channelFactory;

                    channelFactory.Credentials.UserName.UserName = _username;
                    channelFactory.Credentials.UserName.Password = _password;
                }
            }

            return channelFactory.CreateChannel();
        }

        /// <summary>
        /// Cloner denne WcfClientFactory og låser den opp for endringer
        /// slik at nye verdier kan settes.
        /// </summary>
        /// <returns></returns>
        public WcfClientFactory Clone()
        {
            return new WcfClientFactory(_hostname)
            {
                Port = _port,
                Transport = _transport,
                ProxyAddress = _proxyAddress,
                Username = _username,
                Password =  _password,
                UseDefaultWebProxy = _useDefaultWebProxy
            };
        }

        private void EnsureNotLocked()
        {
            if (_locked)
                throw new InvalidOperationException("Kan ikke sette verdi. Bruk Clone()");
        }

        /// <summary>
        /// Get effective endpoint address.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pathOverride"></param>
        /// <returns></returns>
        public string GetEndpointAddress<T>(string pathOverride=null)
        {
            var config = GetServiceContractConfig(typeof(T));
            return GetEndpointAddress(config, pathOverride);
        }

        private string GetEndpointAddress(ServiceContractConfig config, string pathOverride)
        {
            var path = pathOverride ?? config.Path;

            if (_transport == Transport.NetTcp)
                return $"net.tcp://{_hostname}:{_port ?? 9876}{path}";

            if (_transport == Transport.Https)
                return $"https://{_hostname}:{_port ?? 443}{path}";

            throw new ArgumentException($"Ukjent transport \"{_transport}\"");
        }

        private ServiceContractConfig GetServiceContractConfig(Type serviceContractType)
        {
            ServiceContractConfig config;

            if (!_serviceContractConfigs.TryGetValue(serviceContractType.Name, out config))
                throw new ArgumentException($"{serviceContractType.Name} har ingen konfigurasjon knyttet til seg. Bruk .{nameof(AddKnownConfig)}() for å legge til nye konfigurasjoner.");

            return config;
        }

        private Binding CreateBinding(ServiceContractConfig config)
        {
            var binding = _transport == Transport.Https ? ConfigureHttpBinding(config) : ConfigureNetTcpBinding(config);

            binding.ReceiveTimeout = config.ReceiveTimeout;
            binding.SendTimeout = config.SendTimeout;
            binding.OpenTimeout = config.OpenTimeout;
            binding.CloseTimeout = config.CloseTimeout;

            return binding;
        }

        private Binding ConfigureHttpBinding(ServiceContractConfig config)
        {
            var isStreaming = config.TransferMode.HasValue && config.TransferMode != TransferMode.Buffered;
            if (isStreaming) // WsHttpBinding does not support streaming
            {
                var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
                binding.MaxReceivedMessageSize = config.MaxReceivedMessageSize;
                binding.MaxBufferPoolSize = config.MaxBufferPoolSize;
                binding.UseDefaultWebProxy = _useDefaultWebProxy;
                binding.ProxyAddress = _proxyAddress != null ? new Uri(_proxyAddress) : null;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                binding.TransferMode = config.TransferMode.Value;

                return binding;
            }
            else
            {
                var binding = new WSHttpBinding(SecurityMode.Transport);
                binding.MaxReceivedMessageSize = config.MaxReceivedMessageSize;
                binding.MaxBufferPoolSize = config.MaxBufferPoolSize;
                binding.UseDefaultWebProxy = _useDefaultWebProxy;
                binding.ProxyAddress = _proxyAddress != null ? new Uri(_proxyAddress) : null;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

                return binding;
            }
        }

        private NetTcpBinding ConfigureNetTcpBinding(ServiceContractConfig config)
        {
            var binding = new NetTcpBinding(SecurityMode.TransportWithMessageCredential);
            binding.MaxReceivedMessageSize = config.MaxReceivedMessageSize;
            binding.MaxBufferPoolSize = config.MaxBufferPoolSize;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            if (config.TransferMode.HasValue)
                binding.TransferMode = config.TransferMode.Value;

            return binding;
        }
    }
}
