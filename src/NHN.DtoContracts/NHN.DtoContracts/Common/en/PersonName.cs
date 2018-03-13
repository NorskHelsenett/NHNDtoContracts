using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// En persons navn.
    /// </summary>
    [DataContract(Namespace = Namespaces.CommonV1)]
    [Serializable]
    public class PersonName
    {
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
    }
}
