using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.ServiceBus.Data;

namespace NHN.DtoContracts.ServiceBus.Service
{
    [ServiceContract(Namespace = Namespaces.ServiceBusManagerV2, Name = "IServiceBusManagerV2")]
    public interface IServiceBusManagerV2
    {
        /// <summary>
        /// Oppretter abonnement for brukeren som utfører kallet
        /// </summary>
        /// <param name="eventSource">Navn på kilden til hendelsen.</param>
        /// <param name="eventName">(Valgfritt) Navn på selve hendelsetypen. Kan være tom string hvis alle hendelsetyper til en gitt kilde ønskes.
        /// ┌───────────────────────────────────────────────────────────────────────────────────────────┐
        /// │ EventSource        │   EventName                                                          │
        /// ├───────────────────────────────────────────────────────────────────────────────────────────┤
        /// │ AddressRegister    │   SubscriptionEventName.ArBusEvents.*                                │
        /// │ Hpr                │   SubscriptionEventName.HprBusEvents.*                               │
        /// │ Lsr                │   SubscriptionEventName.LsrBusEvents.*                               │
        /// │ Resh               │   SubscriptionEventName.ReshBusEvents.*                              │
        /// └────────────────────┴──────────────────────────────────────────────────────────────────────┘
        /// </param>
        /// <param name="userSystemIdent">Navn på systemet som oppretter og skal bruke abonnementet</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        EventSubscription Subscribe(SubscriptionEventSource eventSource, string eventName, string userSystemIdent);

        /// <summary>
        /// Avslutter og sletter et abonnement
        /// </summary>
        /// <param name="eventSubscription"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void Unsubscribe(EventSubscription eventSubscription);

        /// <summary>
        /// Henter abonnementer registrert på brukeren som utfører kallet
        /// </summary>
        /// <returns>Liste over abonnementer</returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<EventSubscription> GetSubscriptions();
    }
}
