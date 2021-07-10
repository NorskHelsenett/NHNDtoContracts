using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Basisdata for en person.
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrV1)]
    [Serializable]
    public class Person
    {
        /// <summary>
        /// Fødselsnummer, D-nummer eller H-nummer.
        /// </summary>
        [DataMember]
        public string NIN { get; set; }

        /// <summary>
        /// Fornavn.
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Mellomnavn.
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Etternavn.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Fødselsdato.
        /// </summary>
        [DataMember]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Tidspunkt personen døde på.
        /// </summary>
        [DataMember]
        public DateTime? DateOfDeath { get; set; }

        /// <summary>
        /// Kjønn.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/kjonn">kjonn</see> (OID 3101).
        /// </summary>
        [DataMember]
        public Code Sex { get; set; }

        /// <summary>
        /// Statusverdier for personen
        /// Gyldige verdier: OID 5510 og OID 5511
        /// </summary>
        [DataMember]
        public IList<Status> Status { get; set; }

        /// <summary>
        /// Adresser tilhørende personen.
        /// </summary>
        [DataMember]
        public IList<PhysicalAddress> PhysicalAddresses { get; set; }
    }
}
