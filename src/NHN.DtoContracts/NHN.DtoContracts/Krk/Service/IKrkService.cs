using System;
using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.Krk.Data;

namespace NHN.DtoContracts.Krk.Service
{
    /// <summary>
    /// Tjeneste for å hente ut og legge til informasjon i kontaktregister for kommuneoverleger (KRK)
    /// </summary>
    [ServiceContract(Namespace = Namespaces.KrkV1,
        Name = "IKrkService")]
    public interface IKrkService
    {
        /// <summary>
        /// Henter ut alle kommuner og bydeler der denne personen er registrert som deltaker i kommuneoverlegetjenesten
        /// </summary>
        /// <param name="hprId">Helsepersonellnummeret til den aktuelle personen</param>
        /// <returns>Liste over kommuner og bydeler</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var districts = krkService.GetDistrictsForHPR(hprId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * BusinessKommuneoverlegeApiRead
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<string> GetDistrictsForHPR(int hprId);

        /// <summary>
        /// Henter ut alle helsepersonell som er registrert som deltaker i kommuneoverlegetjenesten for denne kommunen eller bydelen
        /// </summary>
        /// <param name="districtID">IDen til en kommune eller bydel (f.eks. 030112) </param>
        /// <returns>Liste over helsepersonellnumre</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var hprNumbers = krkService.GetHPRsForDistrict(districtID);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * BusinessKommuneoverlegeApiRead
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<string> GetHPRsForDistrict(string districtID);

        /// <summary>
        /// Utfører et søk på kommuneoverlegetjenester med gitte parametre.
        /// </summary>
        /// <param name="searchTerm">Tekst for å utføre søk.</param>
        /// <returns>Resultat med liste over søkeresultat.</returns>
        /// <example>
        /// <code>
        /// var searchResult = krkService.SearchKommuneOverlegeInfo(searchTerm);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<SearchResult> SearchKommuneOverlegeInfo(string searchTerm);
    }
}
