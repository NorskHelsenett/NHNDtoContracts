using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Service
{
    /// <summary>
    /// Search parameters for GP Search
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class GPSearchParameters
    {
        /// <summary>
        /// Fulltekst. Fornavn/Mellomnavn/Etternavn
        /// </summary>
        [DataMember]
        public string FullText { get; set; }

        /// <summary>
        /// Hvis satt så har returnerte fastleger et legekontor i kommunen
        /// </summary>
        [DataMember]
        public Code HasGPOfficeInMunicipality { get; set; }

        /// <summary>
        /// IKKE ENNÅ IMPLEMENTERT, kommer i fremtidig release:
        /// Hvis satt, sorter resultatsettet etter distansen til dette koordinatet.
        /// </summary>
        [DataMember]
        public LatitudeLongitude SortResultsByDistanceTo { get; set; }
    }
}