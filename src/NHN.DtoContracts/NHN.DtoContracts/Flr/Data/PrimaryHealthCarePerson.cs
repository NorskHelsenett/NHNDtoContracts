using System;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Basis data for en person tilknyttet et primærhelseteam.
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrV1)]
    [Serializable]

    public class PrimaryHealthCarePerson
    {
        /// <summary>
        /// Identifikator for en person som er medlem av et primærhelseteam.
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// HPR-nummer for personen.
        /// </summary>
        [DataMember]
        public int HprNumber { get; set; }

        /// <summary>
        /// Code som beskriver rollen til en person i kodeverk Helsepersonell (OID=9060).
        /// </summary>
        [DataMember]
        public Code Role { get; set; }

        /// <summary>
        /// Beskriver hvorvidt personen er en vikar eller ikke.
        /// </summary>
        [DataMember]
        public bool IsSubstitute { get; set; }

        /// <summary>
        /// Andel stilling til personen i prosent.
        /// </summary>
        [DataMember]
        public int WorkingPercentage { get; set; }

        /// <summary>
        /// Perioden personen er medlem i primærhelseteam.
        /// </summary>
        [DataMember]
        public Period MembershipPeriod { get; set; }

        /// <summary>
        /// Opprettelsesdato for objektet.
        /// </summary>
        [DataMember]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Dato for sist oppdatering av objektet.
        /// </summary>
        [DataMember]
        public DateTime UpdatedOn { get; set; }
    }
}
