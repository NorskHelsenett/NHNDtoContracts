using NHN.DtoContracts.Common.en;
using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// X
    /// </summary>
    [DataContract(Namespace = OfrNamespace.Name)]
    public class HealthRegisterQuery
    {
        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public string FullText { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public int? BelongsToOrg { get; set; }

        /// <summary>
        /// Type kontrakt
        /// </summary>
        [DataMember]
        public string TypeCodeValue { get; set; }

        /// <summary>
        /// Hvis null, returnerer historiske. Hvis satt, returnerer kontrakter som var gyldige på gitt tidspunkt.
        /// </summary>
        [DataMember]
        public string WasActiveAtTime { get; set; }
    }
}
