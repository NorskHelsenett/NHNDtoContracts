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
        /// The paginated collection og people 
        /// </summary>
        [DataMember]
        public ICollection<PersonOnHealthRegister> Persons { get; set; }

        /// <summary>
        /// The total number of entries of the paginated collection.
        /// </summary>
        [DataMember]
        public int TotalEntries { get; set; }

        /// <summary>
        /// The page nr of the paginated collection.
        /// </summary>
        [DataMember]
        public int Page { get; set; }

        /// <summary>
        /// Size of page in the paginated collection.
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }

        /// <summary>
        /// List of Nins that failed upon lookup.
        /// </summary>
        [DataMember]
        public ICollection<string> PersonNinsNotFound { get; set; }
    }
}
