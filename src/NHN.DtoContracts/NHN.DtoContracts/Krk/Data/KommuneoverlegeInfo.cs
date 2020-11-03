using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Krk.Data
{
    /// <summary>
    /// Helseregister objekt for å legge til/hente ut opplysninger om en helseregisteroppføring i OFR
    /// </summary>
    [DataContract(Namespace = Namespaces.KrkV1)]
    public class KommuneoverlegeInfo
    {

        /// <summary>
        /// ReshId til kommunen som eier kommuneoverlege-tjenesten (KA03)
        /// </summary>
        [DataMember]
        public int OwnerReshId { get; set; }

        /// <summary>
        /// Kommunenr for kommunen kommuneoverlegen tilhører
        /// </summary>
        [DataMember]
        public string KommuneNr { get; set; }

        /// <summary>
        /// Bydelsnr for bydelen kommuneoverlegen tilhører, evt. tom
        /// </summary>
        [DataMember]
        public string BydelsNr { get; set; }

        /// <summary>
        /// Liste over tilknyttede helsepersonells HPR nummer
        /// </summary>
        [DataMember, Required]
        public List<int> AssociatedHcp { get; set; }

        /// <summary>
        /// Telefonnummer for kommuneoverlegen
        /// </summary>
        [DataMember, Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Epost for kommuneoverlegen
        /// </summary>
        [DataMember]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Nødnettnummer for kommuneoverlegen
        /// </summary>
        [DataMember]
        public string EmergencyNetId { get; set; }
    }
}
