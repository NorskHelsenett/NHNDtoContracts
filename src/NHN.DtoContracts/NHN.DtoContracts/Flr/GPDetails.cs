using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.Htk;

namespace NHN.DtoContracts.Flr
{
    /// <summary>
    /// Dette representerer en fastlege.
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
        public Person Practitioner { get; set; }

        /// <summary>
        /// Virksomhet
        /// </summary>
        [DataMember]
        public Business Business { get; set; }

        /// <summary>
        /// Statuskode
        /// </summary>
        [DataMember]
        public Code Status { get; set; }

        /// <summary>
        /// Gyldighetsperiode
        /// </summary>
        [DataMember]
        public Period Period { get; set; }

        /// <summary>
        /// Tilknyttede kontrakter. Kun satt ved relevante leseoperasjoner, må være null ellers.
        /// </summary>
        public ICollection<GPOnContractAssociation> Contracts { get; set; }
    }
}
