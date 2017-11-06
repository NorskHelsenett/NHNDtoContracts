using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Query parameters for GP Contracts
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class GPContractQueryParameters
    {
        /// <summary>
        /// Fulltekst. Fornavn/Mellomnavn/Etternavn/Navn på legekontor/Adresse til legekontor.
        /// Ikke ennå implementert.
        /// </summary>
        [DataMember]
        public string FullText { get; set; }

        /// <summary>
        /// Hvis satt, returner fastelegekontrakter i gitt kommune.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/kommune">kommune</see> (OID 3402).
        /// </summary>
        [DataMember]
        public Code Municipality { get; set; }

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

        /// <summary>
        /// Primært for å hente innholdet i objektet ved logging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Municipality: {Municipality.CodeValue + " " + Municipality.CodeText}, Page: {Page}, PageSize: {PageSize}";
        }
    }
}