using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Status basert p� en periode og kodeverk
    /// </summary>
    [DataContract(Namespace = Namespaces.CommonOldV1)]
    [Serializable]
    public class Status
    {
        /// <summary>
        /// Unik identifikator
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Endret dato
        /// </summary>
        [DataMember]
        public DateTimeOffset Changed { get; set; }

        /// <summary>
        /// Opprettet dato
        /// </summary>
        [DataMember]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Gyldighetsperiode
        /// </summary>
        [DataMember]
        public Period Period { get; set; }

        /// <summary>
        /// Kodeverk
        /// </summary>
        [DataMember]
        public Code Code { get; set; }
    }
}
