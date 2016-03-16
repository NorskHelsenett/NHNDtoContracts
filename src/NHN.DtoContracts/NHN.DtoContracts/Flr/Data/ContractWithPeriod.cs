using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Service
{
    /// <summary>
    /// Brukes for å hente PasientLister i NAV disc format.
    /// </summary>
    [DataContract]
    public class ContractWithPeriod
    {
        /// <summary>
        /// Kontrakt id man ønsker å hente
        /// </summary>
        [DataMember]
        public long ContractId { get; set; }
        /// <summary>
        /// Perioden man ønsker listen hentet for
        /// </summary>
        [DataMember]
        public Period Period { get; set; }
    }
}