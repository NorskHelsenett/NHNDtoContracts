using System.Runtime.Serialization;

namespace NHN.DtoContracts.ServiceBus.Data
{
    /// <summary>
    /// Beskrivelse av et abonnement
    /// </summary>
    [DataContract(Namespace = Namespaces.ServiceBusManagerV2)]
    public class EventSubscription
    {
        /// <summary>
        /// Navn på køen abonnementet er koblet til.
        /// </summary>
        [DataMember]
        public string QueueName { get; set; }

        /// <summary>
        /// This property is used by the calling system to identify different subscriptions on the same topic.
        /// </summary>
        [DataMember]
        public string UserSystemIdent { get; set;  }

        /// <summary>
        /// Navn på kilden til hendelsen.
        /// </summary>
        [DataMember]
        public string EventSource { get; set; }

        /// <summary>
        /// Navn på selve hendelsetypen.
        /// </summary>
        [DataMember]
        public string EventName { get; set; }
    }
}
