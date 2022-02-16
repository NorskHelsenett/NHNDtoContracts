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
        /// Identifiserende navn på systemet eller eier av systemet som oppretter abonnementet.
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
