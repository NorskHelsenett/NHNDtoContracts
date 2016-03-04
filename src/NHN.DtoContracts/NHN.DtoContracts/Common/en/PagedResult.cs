using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Flr;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Generisk paginert resultat.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class PagedResult<T>
    {
        /// <summary>
        /// Paginert resultat.
        /// </summary>
        [DataMember]
        public IList<T> Results { get; set; }

        /// <summary>
        /// Total antall resultat.
        /// </summary>
        [DataMember]
        public int Total { get; set; }
    }
}
