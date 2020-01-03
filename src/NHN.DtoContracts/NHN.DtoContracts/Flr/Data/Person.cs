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
        /// F�dselsnummer, D-nummer eller H-nummer.
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
        /// F�dselsdato.
        /// </summary>
        [DataMember]
        public DateTimeOffset? DateOfBirth { get; set; }

        /// <summary>
        /// Tidspunkt personen d�de p�.
        /// </summary>
        [DataMember]
        public DateTimeOffset? DateOfDeath { get; set; }

        /// <summary>
        /// Kj�nn.
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
        /// Adresser tilh�rende personen.
        /// </summary>
        [DataMember]
        public IList<PhysicalAddress> PhysicalAddresses { get; set; }
    }
}
