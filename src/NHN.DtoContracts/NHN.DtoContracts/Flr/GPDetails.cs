using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr
{
    /// <summary>
    /// Dette representerer en fastlege.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class GPDetails
    {
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

        [DataMember]
        public Code Status { get; set; }

        /// <summary>
        /// Gyldighetsperiode
        /// </summary>
        [DataMember]
        public Period Period { get; set; }
    }
}
