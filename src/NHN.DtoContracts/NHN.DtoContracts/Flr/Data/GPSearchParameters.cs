using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
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
        /// Hvis satt så har returnerte fastleger et legekontor i kommunen.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/kommune">kommune</see> (OID 3402).
        /// </summary>
        [DataMember]
        public Code HasGPOfficeInMunicipality { get; set; }

        /// <summary>
        /// IKKE ENNÅ IMPLEMENTERT, kommer i fremtidig release:
        /// Hvis satt, sorter resultatsettet etter distansen til dette koordinatet.
        /// </summary>
        [DataMember]
        public LatitudeLongitude SortResultsByDistanceTo { get; set; }
        
        /// <summary>
        /// Sidenummer
        /// </summary>
        [DataMember]
        public int Page { get; set; }
        
        /// <summary>
        /// Antall resultater per side
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
    }
}