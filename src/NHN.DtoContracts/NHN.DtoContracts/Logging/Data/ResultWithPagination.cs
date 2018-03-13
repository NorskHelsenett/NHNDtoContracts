using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace NHN.DtoContracts.Logging.Data
{
    /// <summary>
    /// Generisk paginert resultat. 
    /// Retunerer paginert retulatet inkl sidenummer og antall elementer i svaret (antall per side). Utvidet varsjon av PagedResult
    /// </summary>
    [DataContract(Namespace = Namespaces.LogFetchingV1)]
    public class ResultWithPagination<T>
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

        /// <summary>
        /// Antall elementer i svaret (antall per side)
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }

        /// <summary>
        /// Sidenummer som skal hentes (eks: 500 resultater, 50 per side, side 2 returnerer resultat 50-100)
        /// </summary>
        [DataMember]
        public int Page { get; set; }
    }
}
