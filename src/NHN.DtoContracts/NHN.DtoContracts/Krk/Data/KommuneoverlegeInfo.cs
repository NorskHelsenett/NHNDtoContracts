using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Krk.Data
{
    /// <summary>
    /// Helseregister objekt for å hente ut opplysninger om en helseregisteroppføring i kontaktregister for kommuneoverleger (KRK)
    /// </summary>
    [DataContract(Namespace = Namespaces.KrkV1)]
    public class KommuneoverlegeInfo
    {
        /// <summary>
        /// Bydelen som dekkes av denne kommuneoverlegen. Vil i de fleste tilfeller være null som indikerer at det
        /// er den primære kommuneoverlegen for kommunen tjenesten er registrert på.
        /// </summary>
        [DataMember]
        public District District { get; set; }

        /// <summary>
        /// Liste over tilknyttede helsepersonell
        /// </summary>
        [DataMember, Required]
        public ICollection<KrkPerson> RegisteredHprPeople { get; set; }

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
