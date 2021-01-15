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
        /// <param name="hprNumber">Helsepersonellnummeret til den aktuelle personen</param>
        /// <returns>Liste over kommuner og bydeler</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var areas = krkService.GetAreasForHPRNumber(hprId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * BusinessKommuneoverlegeApiRead
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<string> GetAreasForHPRNumber(int hprNumber);

        /// <summary>
        /// Henter ut alle helsepersonell som er registrert som deltaker i kommuneoverlegetjenesten for denne kommunen eller bydelen
        /// </summary>
        /// <param name="areaNumber">Nummer til en kommune eller bydel (f.eks. 030112) </param>
        /// <returns>Liste over helsepersonellnumre</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var hprNumbers = krkService.GetHPRNumbersForArea(areaNumber);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * BusinessKommuneoverlegeApiRead
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<string> GetHPRNumbersForArea(string areaNumber);

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
