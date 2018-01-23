using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.ServiceBusConnector;
using NHN.DtoContracts.ServiceBusConnector.Enum;
using System.ServiceModel;
using System.Threading.Tasks;

namespace NHN.DTOContracts.ServiceBusConnector.Service
{
    /// <summary>
    /// Tjeneste for interaksjon med Service Bus.
    /// Mer informasjon om ServiceBus kan man finne her: <externalLink><linkUri>https://register-web.test.nhn.no/docs/api/?topic=html/4632b3c4-f83d-11e6-bc64-92361f002671.htm</linkUri><linkText>ServiceBus</linkText></externalLink>
    /// </summary>
    [ServiceContract(Namespace = ServiceBusConnectorNamespace.Name, Name = "IServicebusService")]
    public interface IServicebusService
    {
        /// <summary>
        /// Henter informasjon om en meldings status på service bus. Hvor det søkes etter meldingen avhenger av køene som er koblet til virksomheten i Adresseregisteret.
        /// </summary>
        /// <param name="herid">HerId'en til virksomheten som er mottaker for gitt melding</param>
        /// <param name="messageId">Meldings-id på meldingen det søkes på</param>
        /// <returns>En enum med statusverdi for gitt melding.</returns>
        /// <example>
        /// <code>
        /// var status = serviceBusService.GetMessageStatus(98557, "a0424e93-dfce-4497-9ae0-083aab52f86a");
        /// </code>
        /// </example>
        /// <exception cref="FaultException">Kastes med GenericFault hvis supplert herId er ugyldig.</exception>
        /// <exception cref="FaultException">Kastes med melding "Error getting status for herId" dersom undertjenesten feiler</exception>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * ServiceBusUser
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Task<ServiceBusStatus> GetMessageStatus(int herid, string messageId);
    }
}
