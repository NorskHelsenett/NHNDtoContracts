using System;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Basis data for en fastlegekontrakt i FLR som er tilknyttet et primærhelseteam
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrV1)]
    [Serializable]

    public class PrimaryHealthCareContract
    {
        /// <summary>
        /// Identifikator for kontrakten.
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// Identifikator til kontrakten i Fastlegeregisteret.
        /// </summary>
        [DataMember]
        public long FlrId { get; set; }

        /// <summary>
        /// Perioden til kontrakten i primærhelseteam.
        /// </summary>
        [DataMember]
        public Period MembershipPeriod { get; set; }
    }
}
