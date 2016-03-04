using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Dette representerer en fastlege. Brukes når fokuset er på selve fastlegen, og ikke f.eks kontrakt eller pasient.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class GPDetails
    {
        /// <summary>
        /// HPR nummeret til legen
        /// </summary>
        [DataMember]
        public int HprNumber { get; set; }

        /// <summary>
        /// Lege
        /// </summary>
        [DataMember]
        public Person GP { get; set; }

        /// <summary>
        /// Tilknyttede kontrakter. Kun satt ved relevante leseoperasjoner, må være null ellers.
        /// </summary>
        [DataMember]
        public IList<GPOnContractAssociation> Contracts { get; set; }
    }
}
