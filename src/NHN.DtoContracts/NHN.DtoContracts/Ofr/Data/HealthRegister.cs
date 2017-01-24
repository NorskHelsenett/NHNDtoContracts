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
        [DataMember, Required]
        public int Id { get; set; }

        /// <summary>
        /// Navnet på helseregisteroppføringen
        /// </summary>
        [DataMember, Required]
        public string Name { get; set; }

        /// <summary>
        /// Kor beskrivelse, maks 200 karakterer
        /// </summary>
        [DataMember]
        public string Description { get; set; }

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
        /// Årsak til at helseregisteret er oppført
        /// </summary>
        [DataMember]
        public string ReasonForListing { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public Code LegalJustification { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public string[] LegalParagraphs { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember, Required]
        public Code Type { get; set; }

        /// <summary>
        /// Fysiske adresser for oppføringen
        /// </summary>
        [DataMember]
        public IList<PhysicalAddress> PhysicalAddresses { get; set; }

        /// <summary>
        /// Hjemmesiden til oppføringen
        /// </summary>
        [DataMember]
        public ElectronicAddress RegisterHomepage { get; set; }

        /// <summary>
        /// Lenke innsynsrett
        /// </summary>
        [DataMember]
        public ElectronicAddress RegisterPrivacyUrl { get; set; }

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
