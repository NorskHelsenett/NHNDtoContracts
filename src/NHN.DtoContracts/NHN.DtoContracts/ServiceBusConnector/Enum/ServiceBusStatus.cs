using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.ServiceBusConnector.Enum
{
    /// <summary>
    /// Status for melding i service bus
    /// </summary>
    /// 
    /// <remarks>
    /// Denne er definert med [Flags], men dette er misvisende.
    /// Enumen er ikke ment å brukes med `HasFlag(...)`
    /// </remarks>
    [DataContract(Namespace = Namespaces.ServiceBusConnectorOldV1)]
    [Flags] // Misvisende, men kan ikke fjernes
    [Serializable]
    public enum ServiceBusStatus
    {
        /// <summary>
        /// Meldingen er i kø
        /// </summary>
        [EnumMember]
#pragma warning disable CA1008 // Enums should have zero value
        InQueue,
#pragma warning restore CA1008 // Enums should have zero value

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
