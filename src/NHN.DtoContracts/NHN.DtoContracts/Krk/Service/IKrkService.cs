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
        //TODO. Dokumenter hvilke roller som kreves

        /// <summary>
        /// Henter ut alle kommuner og bydeler der denne personen er registrert som deltaker i kommuneoverlegetjenesten
        /// </summary>
        /// <param name="hprId">Helsepersonellnummeret til den aktuelle personen</param>
        /// <returns>Liste over kommuner og bydeler</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var districts = krkService.GetKommunerAndBydelForHPR(hprId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// *
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<string> GetKommunerAndBydelForHPR(int hprId);

        /// <summary>
        /// Henter ut alle helsepersonell som er registrert som deltaker i kommuneoverlegetjenesten for denne kommunen eller bydelen
        /// </summary>
        /// <param name="districtID">IDen til en kommune eller bydel (f.eks. 030112) </param>
        /// <returns>Liste over helsepersonellnumre</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var hprNumbers = krkService.GetHPRForKommuneOrBydel(districtID);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// *
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<string> GetHPRForKommuneOrBydel(string districtID);


        //TODO: Hva skjer dersom man gir inn IDen til oslo, skal alle bydeler komme med? Dokumenterer som om det stemmer
        /// <summary>
        /// Henter ut informasjon om kommuneoverlegetjenesten for denne kommunen eller bydelen.
        ///
        /// For kommuner uten egen kommuneoverlegetjeneste på bydelsnivå vil denne listen inneholde ett innslag.
        ///
        /// For kommuneoverlegetjenester som leveres av en kommune i et interkommunalt samarbeid,
        /// vil denne metoden gi samme resultat om du gir inn et kommunenummer i dekningsområdet til tjenesten.
        /// </summary>
        /// <param name="districtID">IDen til en kommune eller bydel (f.eks. 030112) </param>
        /// <returns>Liste med informasjon om kommuneoverlegetjenesten</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var infoObjects = krkService.GetKommuneOverlegeInfos(districtID);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// *
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<KommuneoverlegeInfo> GetKommuneOverlegeInfos(string districtID);


        /// <summary>
        /// Utfører et søk på kommuneoverlegetjenester med gitte parametre.
        /// </summary>
        /// <param name="searchTerm">Tekst for å utføre søk.</param>
        /// <returns>Resultat med liste over kommuneoverlegeinfo.</returns>
        /// <example>
        /// <code>
        /// var searchResult = krkService.SearchKommuneOverlegeInfo(searchTerm);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// *
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<KommuneoverlegeInfo> SearchKommuneOverlegeInfo(string searchTerm);
    }
}
