using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// Data for å legge til en ny personoppføringe på en helseregisteroppføring
    /// </summary>
    [DataContract(Namespace = Namespaces.OfrV1)]
    public class AddPersonData
    {
        /// <summary>
        /// Fødselsnummeret til personen man ønsker å legge til
        /// </summary>
        [DataMember, Required]
        public string Nin { get; set; }

        /// <summary>
        /// En ekstern referanse man kan legge til med personen
        /// </summary>
        [DataMember]
        public string ExternalRef { get; set; }

        /// <summary>
        /// Når denne personoppføringen skal starte å være gyldig
        /// </summary>
        [DataMember, Required]
        public DateTime StartPeriod { get; set; }
    }
}
