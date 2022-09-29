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
        /// Oppretter et abonnement for brukeren som utfører kallet.
        /// Returnerer eksisterende abonnement dersom det allerede er opprettet for angitte parametre.
        /// </summary>
        /// <param name="eventSource">Navn på kilden til hendelsen.</param>
        /// <param name="eventName">(Valgfritt) Navn på selve hendelsetypen. Kan være tom string hvis alle hendelsetyper til en gitt kilde ønskes.
        /// <list type="table">
        ///     <listheader>
        ///         <term> EventSource </term>
        ///         <description> EventName </description>
        ///     </listheader>
        ///     <item>
        ///         <term> AddressRegister </term>
        ///         <description> En av verdiene i <see cref="SubscriptionEventName.ArBusEvents">SubscriptionEventName.ArBusEvents</see> </description>
        ///     </item>
        ///     <item>
        ///         <term> Hpr </term>
        ///         <description> En av verdiene i <see cref="SubscriptionEventName.HprBusEvents">SubscriptionEventName.HprBusEvents</see> </description>
        ///     </item>
        ///     <item>
        ///         <term> Lsr </term>
        ///         <description> En av verdiene i <see cref="SubscriptionEventName.LsrBusEvents">SubscriptionEventName.LsrBusEvents</see> </description>
        ///     </item>
        ///     <item>
        ///         <term> Resh </term>
        ///         <description> En av verdiene i <see cref="SubscriptionEventName.ReshBusEvents">SubscriptionEventName.ReshBusEvents</see> </description>
        ///     </item>
        /// </list>
        /// </param>
        /// <param name="userSystemIdent">Navn på systemet som oppretter og skal bruke abonnementet. Gyldige tegn er tall, bokstaver og underscore</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        EventSubscription Subscribe(SubscriptionEventSource eventSource, string eventName, string userSystemIdent);

        /// <summary>
        /// Avslutter og sletter et abonnement
        /// </summary>
        /// <param name="queueName">Navn og identifikator til køen abonnementet er koblet til.</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void Unsubscribe(string queueName);

        /// <summary>
        /// Henter abonnementer registrert på brukeren som utfører kallet
        /// </summary>
        /// <returns>Liste over abonnementer</returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
#pragma warning disable CA1024 // Use properties where appropriate
        IList<EventSubscription> GetSubscriptions();
#pragma warning restore CA1024 // Use properties where appropriate
    }
}
