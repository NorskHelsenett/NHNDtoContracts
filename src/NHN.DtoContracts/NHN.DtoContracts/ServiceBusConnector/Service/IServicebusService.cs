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
        /// Henter informasjon om en melding finnes i en av herid's køer
        /// </summary>
        /// <param name="herid">HerId</param>
        /// <param name="messageId">Meldings-id på meldingen det søkes på</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Task<ServiceBusStatus> GetMessageStatus(int herid, string messageId);
    }
}
