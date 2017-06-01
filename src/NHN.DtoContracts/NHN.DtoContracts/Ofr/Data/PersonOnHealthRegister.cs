using System;
using NHN.DtoContracts.Common.en;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// Inneholder en personoppføring for OFR, inbkluderer helseregisteret personen er oppført på
    /// </summary>
    [DataContract(Namespace = OfrNamespace.Name)]
    public class PersonOnHealthRegister
    {
        /// <summary>
        /// Intern identifikator for oppføringen
        /// </summary>
        [DataMember, Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Fødelsnummeret til personen
        /// </summary>
        [DataMember, Required]
        public string Nin { get; set; }

        /// <summary>
        /// Navnet på personen, fornavn + eventuelt mellomnavn + etternavn
        /// </summary>
        [DataMember]
        public PersonName Name { get; set; }

        /// <summary>
        /// Ekstern referanse som skal føres opp i OFR
        /// </summary>
        [DataMember]
        public string ExternalRef { get; set; }

        /// <summary>
        /// Gyldighetsperiode for oppføringen
        /// </summary>
        [DataMember]
        public Period Period { get; set; }

        /// <summary>
        /// Identifikator for helseregisteret personen står oppført på.
        /// </summary>
        [DataMember, Required]
        public Guid HealthRegisterId { get; set; }

        /// <summary>
        /// Denne skal aldri settes ved skriving til registeret, men vil være tilgjengelig på
        /// operasjoner hvor perspektivet er en innbygger, f.eks GetHealthRegistersFor.
        /// </summary>
        [DataMember]
        public HealthRegister HealthRegister { get; set; }
    }
}
