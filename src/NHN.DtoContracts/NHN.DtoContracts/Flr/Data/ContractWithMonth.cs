using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Brukes for å hente PasientLister i NAV disc format.
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrLegacyV1)]
    public class ContractWithMonth
    {
        /// <summary>
        /// Kontrakt id man ønsker å hente
        /// </summary>
        [DataMember]
        public long ContractId { get; set; }

        /// <summary>
        /// Måneden man ønsker listen hentet for
        /// </summary>
        [DataMember]
        public DateTime Month { get; set; }
    }
}
