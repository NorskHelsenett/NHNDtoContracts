using System;
using System.ServiceModel;

namespace NHN.WcfClientFactory
{
    /// <summary>
    /// WCF-konfigurasjon.
    /// </summary>
    public class ServiceContractConfig
    {
        /// <summary>
        /// Path til endpointet.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// maxReceivedMessageSize på bindingen.
        /// </summary>
        public long MaxReceivedMessageSize { get; set; } = 200000000;

        /// <summary>
        /// maxBufferPoolSize på bindingen.
        /// </summary>
        public long MaxBufferPoolSize { get; set; } = 200000000;
        
        /// <summary>
        /// receiveTimeout på bindingen.
        /// </summary>
        public TimeSpan ReceiveTimeout { get; set; } = TimeSpan.FromSeconds(70);
        
        /// <summary>
        /// sendTimeout på bindingen.
        /// </summary>
        public TimeSpan SendTimeout { get; set; } = TimeSpan.FromSeconds(70);
        
        /// <summary>
        /// openTimeout på bindingen.
        /// </summary>
        public TimeSpan OpenTimeout { get; set; } = TimeSpan.FromSeconds(5);
        
        /// <summary>
        /// closeTimeout på bindingen.
        /// </summary>
        public TimeSpan CloseTimeout { get; set; } = TimeSpan.FromSeconds(5);
        
        /// <summary>
        /// transferMode på bindingen.
        /// </summary>
        public TransferMode? TransferMode { get; set; } = null;

        /// <summary>
        /// Oppretter et nytt konfigurasjonsobject med angitt path.
        /// </summary>
        /// <param name="path">Path til endpointet.</param>
        public ServiceContractConfig(string path)
        {
            Path = path;
        }
    }
}