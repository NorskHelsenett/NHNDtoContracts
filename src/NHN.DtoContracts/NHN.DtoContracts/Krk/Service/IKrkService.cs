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
        /// Legger til info om en kommuneoverlege
        /// </summary>
        /// <param name="cpinfo">Objekt som inneholder opplysninger om en kommuneoverlege.</param>
        /// <returns>Objekt med den nye oppføringen som er blitt lagt til i registeret.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var kommuneoverlege = krkService.AddCountyPhysicianInfo(koinfo);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * 
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        KommuneoverlegeInfo UpdateKommuneoverlegeInfo(KommuneoverlegeInfo kommuneoverlegeInfo);

        /// <summary>
        /// Henter info om en kommuneoverlege
        /// </summary>
        /// <param name="herId">ReshId for kommuneoverlegens oppføring.</param>
        /// <returns>Objekt med oppføringen med spesifisert id fra registeret.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var kommuneoverlege = krkService.GerKommuneoverlegeInfo(herId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * 
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        KommuneoverlegeInfo GetKommuneoverlegeInfo(int reshId);

        /// <summary>
        /// Henter info om en kommuneoverlege med bydel/kommune som input
        /// </summary>
        /// <param name="herId">ReshId for kommuneoverlegens oppføring.</param>
        /// <returns>Objekt med kommuneoverlege for bydelen/kommunen.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var kommuneoverlege = krkService.GerKommuneoverlegeInfoForDistrict(districtCode);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * 
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        KommuneoverlegeInfo GetKommuneoverlegeInfoForDistrict(int districtCode);

        /// <summary>
        /// Utfører et søk på helseregisteroppføringer med gitte parametre.
        /// </summary>
        /// <param name="query">Tekst for å utføre søk.</param>
        /// <returns>Resultat med liste over kommuneoverlegeinfo.</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * 
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<KommuneoverlegeInfo> Search(string query);
    }
}
