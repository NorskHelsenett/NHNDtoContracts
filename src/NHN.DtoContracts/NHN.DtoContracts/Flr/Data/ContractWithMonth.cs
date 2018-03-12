using System;
using System.Collections;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Brukes for � hente PasientLister i NAV disc format.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.FlrDataV1)]
    public class ContractWithMonth
    {
        /// <summary>
        /// Kontrakt id man �nsker � hente
        /// </summary>
        [DataMember]
        public long ContractId { get; set; }

        /// <summary>
        /// M�neden man �nsker listen hentet for
        /// </summary>
        [DataMember]
        public DateTime Month { get; set; }
    }
}
