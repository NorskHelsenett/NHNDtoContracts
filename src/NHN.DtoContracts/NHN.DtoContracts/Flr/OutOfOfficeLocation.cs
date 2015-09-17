using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr
{
    /// <summary>
    /// Representerer informasjon om et utekontor
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class OutOfOfficeLocation
    {
        /// <summary>
        /// ID. This Id is owned by FLO.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Beskrivelse av utekontoret
        /// </summary>
        [DataMember]
        public string Description { get; set; } 

        /// <summary>
        /// Adressen til utekontoret.
        /// </summary>
        [DataMember]
        public PhysicalAddress Address { get; set; }

        /// <summary>
        /// Åpningstider
        /// </summary>
        [DataMember]
        public OpeningHours OpeningHours { get; set; }

        /// <summary>
        /// For hvilken periode er dette utekontoret relevant
        /// </summary>
        [DataMember]
        public Period Valid { get; set; }
    }
}