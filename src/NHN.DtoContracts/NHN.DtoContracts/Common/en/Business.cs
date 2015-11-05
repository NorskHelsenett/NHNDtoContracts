using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Virksomhet
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglishOld)]
    public class Business
    {
        /// <summary>
        /// Organisajonsnummer på enheten
        /// </summary>
        [DataMember]
        public int OrganizationNumber { get; set; }

        /// <summary>
        /// Det registrerte juridiske navnet på enheten.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Visningsnavn på enheten.
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gyldighetstid (til/fra).
        /// </summary>
        [DataMember]
        public Period Valid { get; set; }

        /// <summary>
        /// Organisajonsnummer på eventuell overliggende enhet.
        /// </summary>
        [DataMember]
        public int? ParentOrganizationNumber { get; set; }

        /// <summary>
        /// Organisajonsnavn på eventuell overliggende enhet.
        /// </summary>
        [DataMember]
        public string ParentOrganizationName { get; set; }

        /// <summary>
        /// Underliggende bedrifter under en topp-organisasjon.
        /// Dette business-objektet vil aldri inneholde detaljobjekter!
        /// </summary>
        [DataMember]
        public ICollection<Business> Children { get; set; }

        /// <summary>
        /// Dato og tid for siste endring til objektet.
        /// </summary>
        [DataMember]
        public DateTime LastChanged { get; set; }

        /// <summary>
        /// Egenskaper for enheten.
        /// </summary>
        [DataMember]
        public IList<Code> Properties { get; set; }

        /// <summary>
        /// Fysiske addresser (f.eks. besøks-, post- og fakturaadresse).
        /// Gyldige verdier: OID 3401
        /// </summary>
        [DataMember]
        public IList<PhysicalAddress> PhysicalAddresses { get; set; } = new List<PhysicalAddress>();

        /// <summary>
        /// Liste over elektroniske addresser.
        /// Gyldige verdier: OID 9044
        /// </summary>
        [DataMember]
        public IList<ElectronicAddress> ElectronicAddresses { get; set; } = new List<ElectronicAddress>();

        /// <summary>
        /// Ansvarlig person for virksomheten/enheten.
        /// </summary>
        [DataMember]
        public string ResponsiblePerson { get; set; }

        /// <summary>
        /// Kommunenummer.
        /// Gyldige verdier: OID 3402
        /// </summary>
        [DataMember]
        public Code Municipality { get; set; }

        /// <summary>
        /// Næringskoder.
        /// Gyldige verdier: SN2007
        /// </summary>
        [DataMember]
        public IList<Code> IndustryCodes { get; set; }

        /// <summary>
        /// Industriell sektorkode.
        /// </summary>
        [DataMember]
        public Code SectorCode { get; set; }

        /// <summary>
        /// Hvorvidt det er en statlig/kommunal eller privateid bedrift. Utledet av SectorCode.
        /// Er null når det er ukjent.
        /// </summary>
        [DataMember]
        public bool? IsGovernmentCompany { get; set; }

        /// <summary>
        /// Åpningstider for bedriften. Hvis feltet er null så arves data fra overliggende enhet.
        /// </summary>
        [DataMember]
        public OpeningHours OpeningHours { get; set; }

        /// <summary>
        /// Når bedriften er sist oppdatert
        /// </summary>
        [DataMember]
        public DateTime UpdatedOn { get; set; }
    }
}
