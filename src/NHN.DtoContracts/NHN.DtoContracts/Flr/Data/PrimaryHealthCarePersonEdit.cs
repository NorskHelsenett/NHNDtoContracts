using System;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Basisdata for en person.
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrV1)]
    [Serializable]

    public class PrimaryHealthCarePersonEdit
    {
        /// <summary>
        /// Identifikator for primærhelseteamperson.
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// HPR-nummer for personen.
        /// </summary>
        [DataMember]
        public int HprNumber { get; set; }

        /// <summary>
        /// Kodeverdi for en Code som beskriver rollen til en person i kodeverk Helsepersonell (OID=9060).
        /// </summary>
        [DataMember]
        public string RoleId { get; set; }

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
    }
}
