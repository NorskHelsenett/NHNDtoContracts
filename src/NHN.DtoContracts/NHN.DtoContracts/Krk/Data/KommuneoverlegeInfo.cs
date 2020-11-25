using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Krk.Data
{
    /// <summary>
    /// Helseregister objekt for å legge til/hente ut opplysninger om en helseregisteroppføring i kontaktregister for kommuneoverleger (KRK)
    /// </summary>
    [DataContract(Namespace = Namespaces.KrkV1)]
    public class KommuneoverlegeInfo
    {

        /// <summary>
        /// Organisasjonen kommuneoverlegetjenesten er registrert på
        /// </summary>
        //TODO: Trenger vi denne? Kun ved skriving?
        [DataMember]
        public int? OrganizationNumber { get; set; }

        /// <summary>
        /// Områdene som dekkes av denne kommuneoverlegeinformasjonen.
        /// Kan være kommuner og bydeler
        /// </summary>
        [DataMember]
        public ICollection<string> DistrictIds { get; set; }

        /// <summary>
        /// Liste over tilknyttede helsepersonells HPR nummer
        /// </summary>
        [DataMember, Required]
        public ICollection<int> RegisteredHprIds { get; set; }

        /// <summary>
        /// Telefonnummer for kommuneoverlegen
        /// </summary>
        [DataMember]
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
        public string PublicSafetyNetId { get; set; }
    }
}
