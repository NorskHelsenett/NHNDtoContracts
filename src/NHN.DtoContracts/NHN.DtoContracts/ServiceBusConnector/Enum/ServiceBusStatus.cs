using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.ServiceBusConnector.Enum
{
    /// <summary>
    /// Status for melding i service bus
    /// </summary>
    [DataContract(Namespace = "http://register.nhn.no/ServiceBusConnector")]
    [Flags]
    [Serializable]
    public enum ServiceBusStatus
    {
        /// <summary>
        /// Ukjent
        /// </summary>
        [EnumMember]
        Unknown,
        /// <summary>
        /// Meldingen er i kø
        /// </summary>
        [EnumMember]
        InQueue,
        /// <summary>
        /// Meldingen er ikke på kø
        /// </summary>
        [EnumMember]
        NotInQueue,
        /// <summary>
        /// Melding i deadletter-kø
        /// </summary>
        [EnumMember]
        DeadLetter
    }
}
