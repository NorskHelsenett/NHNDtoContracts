using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// X
    /// </summary>
    [DataContract(Namespace = OfrNamespace.Name)]
    public class PersonAssociations
    {
        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public ICollection<PersonOnHealthRegister> Persons { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public int TotalEntries { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public int Page { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
    }
}
