using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Krk.Data
{
    /// <summary>
    /// Objekt for å representere søkeresultatet fra KRK.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Organisasjonsnummeret til enheten som tjenesten KA03 er registrerte på
        /// </summary>
        [DataMember]
        public int OrgNumber { get; set; }

        /// <summary>
        /// Navnet til enheten som tjenesten KA03 er registrerte på
        /// </summary>
        [DataMember]
        public string UnitName { get; set; }

        /// <summary>
        /// Navnet på kommunen som resulterte i dette treffet
        /// </summary>
        [DataMember]
        public string MunicipalityName { get; set; }

        /// <summary>
        /// Navnet på fylket som resulterte i dette treffet
        /// </summary>
        [DataMember]
        public string CountyName { get; set; }

        /// <summary>
        /// Liste over alle kommuner som deler på denne kommmuneoverlegetjenesten (interkommunalt sammarbeid)
        /// </summary>
        [DataMember]
        public ICollection<District> CoveredMunicipalities { get; set; }

        /// <summary>
        /// Liste over ekstrainformasjon om kommuneoverleger. Normalt vil det være et element i listen, men noen
        /// kommuner har egne kommuneoverlegetjenester pr bydel, og det vil da kunne være flere innslag i denne listen.
        /// </summary>
        [DataMember]
        public ICollection<KommuneoverlegeInfo> KommuneoverlegeInfos { get; set; }
    }
}
