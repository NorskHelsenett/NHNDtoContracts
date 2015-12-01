using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Basisdata for en person.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    [Serializable]
    public class Person
    {
        /// <summary>
        /// Fødselsnummer, D-nummer eller H-nummer.
        /// </summary>
        [DataMember]
        public string SSN { get; set; }

        /// <summary>
        /// Fornavn
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Mellomnavn
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Etternavn
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Fødselsdato
        /// </summary>
        [DataMember]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Tidspunkt perioden døde på
        /// </summary>
        [DataMember]
        public DateTime DateOfDeath { get; set; }

        /// <summary>
        /// Kjønn. Gyldig simpletype er "kjonn".
        /// </summary>
        [DataMember]
        public Code Sex { get; set; }

        /// <summary>
        /// Statusverdier for personen
        /// Gyldige verdier: OID 5510 og OID 5511
        /// </summary>
        [DataMember]
        public List<Status> Status { get; set; }
    }
}