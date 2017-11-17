using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.ServiceBusConnector;
using NHN.DtoContracts.ServiceBusConnector.Enum;
using System.ServiceModel;
using System.Threading.Tasks;

namespace NHN.DTOContracts.ServiceBusConnector.Service
{
    /// <summary>
    /// Tjeneste for interaksjon med Service Bus 
    /// </summary>
    [ServiceContract(Namespace = ServiceBusConnectorNamespace.Name, Name = "IServicebusService")]
    public interface IServicebusService
    {
        /// <summary>
        /// Henter informasjon om en meldings status på service bus. Hvor det søkes etter meldingen avhenger av køene som er koblet til virksomheten i Adresseregisteret.
        /// </summary>
        /// <param name="herid">Virksomhetens herId</param>
        /// <param name="messageId">Meldings-id på meldingen det søkes på</param>
        /// <returns>Status for meldingen</returns>
        /// <example>
        /// <code>
        /// serviceBusService.GetMessageStatus(98557, a0424e93-dfce-4497-9ae0-083aab52f86a);
        /// </code>
        /// </example>
        /// <exception cref="FaultException">Kastes om oppslag mot servicebus feiler for en av </exception>
        /// <permission>Krever rollen ServiceBus-bruker</permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Task<ServiceBusStatus> GetMessageStatus(int herid, string messageId);
    }
}
