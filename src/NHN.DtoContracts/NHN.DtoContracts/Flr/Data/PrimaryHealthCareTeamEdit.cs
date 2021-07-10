using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Data for redigering av et primærhelseteam
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrV1)]
    [Serializable]

    public class PrimaryHealthCareTeamEdit
    {
        /// <summary>
        /// Identifikator for primærhelseteam.
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// Organisasjonsnummer for tilhørende organisasjon.
        /// </summary>
        [DataMember]
        public int OrganizationNumber { get; set; }

        /// <summary>
        /// Liste over helsepersonell knyttet til primærhelseteamet.
        /// </summary>
        [DataMember]
        public List<PrimaryHealthCarePersonEdit> PrimaryHealthCarePeople { get; set; }

        /// <summary>
        /// Liste over faslegekontrakter tilknyttet primærhelseteamet.
        /// </summary>
        [DataMember]
        public List<PrimaryHealthCareContractEdit> PrimaryHealthCareContracts { get; set; }

        /// <summary>
        /// HPR-nummer til lederen for primærhelseteamet.
        /// </summary>
        [DataMember]
        public int PrimaryHealthCareLeaderHprNumber { get; set; }

        /// <summary>
        /// Versjon fra FLO.
        /// </summary>
        [DataMember]
        public int Version { get; set; }
    }
}
