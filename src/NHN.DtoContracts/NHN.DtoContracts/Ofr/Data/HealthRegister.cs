using System;
using NHN.DtoContracts.Common.en;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// X
    /// </summary>
    [DataContract(Namespace = OfrNamespace.Name)]
    public class HealthRegister
    {
        /// <summary>
        /// Unik id for denne helseregisteroppføringen
        /// </summary>
        [DataMember]
        public Guid guid { get; set; }

        /// <summary>
        /// Navnet på helseregisteroppføringen
        /// </summary>
        [DataMember, Required]
        public string Name { get; set; }

        /// <summary>
        /// Kortnavn/visningsnavn på helseregisteret. Maks lengde 10 tegn
        /// </summary>
        [DataMember, Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Kort beskrivelse, maks 200 karakterer
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Tekstlig beskrvelse av hvorfor en person vil være ført opp i registeret
        /// </summary>
        [DataMember]
        public string ReasonForListing { get; set; }

        /// <summary>
        /// Organisasjonsnummer til eieren av oppføringen
        /// </summary>
        [DataMember, Required]
        public int OwnerOrganizationNumber { get; set; }

        /// <summary>
        /// Navn på org som eier registeret. Utledet fra navnet på bedriften.
        /// </summary>
        [DataMember]
        public string OwnerName { get; set; }

        /// <summary>
        /// Visningsnavnet til eieren av oppføringen
        /// </summary>
        [DataMember]
        public string OwnerDisplayName { get; set; }

        /// <summary>
        /// HerID for direkte elektronisk kommunikasjon
        /// </summary>
        [DataMember]
        public int? HerId { get; set; }

        /// <summary>
        /// Rettslig grunnlag: Samtykkebasert, Reservasjonsbasert, Lovpålagt.
        /// </summary>
        [DataMember]
        public Code LegalJustification { get; set; }

        /// <summary>
        /// Strenger som unikt representerer lovdata-type lenker.
        /// </summary>
        [DataMember]
        public string[] LegalParagraphs { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember, Required]
        public Code Type { get; set; }

        /// <summary>
        /// E_URL type adresse som viser til hjemmesiden for registeret
        /// </summary>
        [DataMember]
        public ElectronicAddress HomePageLink { get; set; }

        /// <summary>
        /// E_URL type adresse som viser til innsynsrett-informasjon.
        /// </summary>
        [DataMember]
        public ElectronicAddress PrivacyTermsLink { get; set; }

        /// <summary>
        /// Fysiske adresser for eieren av registeret
        /// </summary>
        [DataMember]
        public IList<PhysicalAddress> PhysicalAddresses { get; set; }

        /// <summary>
        /// Elektoniske adresser til eieren av reigsteret
        /// </summary>
        [DataMember]
        public IList<ElectronicAddress> ElectronicAddresses { get; set; }

        /// <summary>
        /// Perioden for når data i oppføringen skal eksistere
        /// </summary>
        [DataMember]
        public Period RegisterDataExists { get; set; }

        /// <summary>
        /// Perioden for når innsamlingen av informasjon foregikk
        /// </summary>
        [DataMember, Required]
        public Period DataCapturePeriod { get; set; }

        /// <summary>
        /// Hvorvidt informasjonen i denne oppføringen er av sensitiv natur
        /// </summary>
        [DataMember]
        public bool IsSensitive { get; set; }

        /// <summary>
        /// Hvorvidt alle innbyggere potensielt sett er på dette registeret
        /// </summary>
        [DataMember]
        public bool RelevantForAllPeople { get; set; }
    }
}
