using System;
using NHN.DtoContracts.Common.en;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// Helseregister objekt for å legge til/hente ut opplysninger om en helseregisteroppføring i OFR
    /// </summary>
    [DataContract(Namespace = Namespaces.OfrV1)]
    public class HealthRegister
    {
        /// <summary>
        /// Unik id for denne helseregisteroppføringen
        /// </summary>
        [DataMember]
#pragma warning disable CA1720 // Identifier contains type name
        public Guid guid { get; set; }
#pragma warning restore CA1720 // Identifier contains type name

        /// <summary>
        /// Unik, brukerdefinert id
        /// </summary>
        [DataMember]
        public string RegisterId { get; set; }

        /// <summary>
        /// Navnet på helseregisteroppføringen
        /// </summary>
        [DataMember, Required]
        public string Name { get; set; }

        /// <summary>
        /// Kortnavn/visningsnavn på helseregisteret. Maks lengde 10 tegn
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }

        /// <summary>
        /// Kort beskrivelse, maks 600 karakterer
        /// </summary>
        [DataMember, Required]
        public string Description { get; set; }

        /// <summary>
        /// Tekstlig beskrvelse av hvorfor en person vil være ført opp i registeret
        /// </summary>
        [DataMember, Required]
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
        /// Rettslig grunnlag for helseregisteroppføringen, representer av en kode i kodeverk.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/ofr_hjemmel">ofr_hjemmel</see>.
        /// </summary>
        [DataMember, Required]
        public Code LegalJustification { get; set; }

        /// <summary>
        /// Strenger som unikt representerer lovdata-type lenker.
        /// </summary>
        [DataMember]
        public IList<string> LegalParagraphs { get; set; }

        /// <summary>
        /// Type helseregister, representert av en kode i kodeverk.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/ofr_helseregistertype">ofr_helseregistertype</see>.
        /// </summary>
        [DataMember, Required]
        public Code Type { get; set; }

        /// <summary>
        /// Fysiske adresser for eieren av registeret
        /// Type-kode må være med CodeValue enten RES (Besøksadresse) eller PST (Postboks).
        /// </summary>
        [DataMember, Required]
        public IList<PhysicalAddress> PhysicalAddresses { get; set; }

        /// <summary>
        /// Elektoniske adresser til eieren av registeret. I hovedsak er dette snakk om en Hjemmeside representert av kodeverdien E_URL, 
        /// og en Adresselenke for innsynsrett representert av kodeverdien E_PTL 
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/type_adressekomponeneter">type_adressekomponeneter</see> (OID 9044).
        /// </summary>
        [DataMember, Required]
        public IList<ElectronicAddress> ElectronicAddresses { get; set; }

        /// <summary>
        /// Perioden for når data i oppføringen skal eksistere
        /// </summary>
        [DataMember, Required]        
        public Period RegisterDataExists { get; set; }

        /// <summary>
        /// Perioden for når innsamlingen av informasjon foregikk
        /// </summary>
        [DataMember]
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
