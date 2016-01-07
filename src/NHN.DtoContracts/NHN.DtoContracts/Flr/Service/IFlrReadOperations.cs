using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using System;
using NHN.DtoContracts.Flr.Data;

namespace NHN.DtoContracts.Flr.Service
{
    /// <summary>
    /// Leseoperasjoner for FLR (GP v2)
    /// </summary>
    [ServiceContract(Namespace = FlrXmlNamespace.V1)]
    public interface IFlrReadOperations
    {
        /// <summary>
        /// Henter fastlege for en gitt person.
        /// </summary>
        /// <remarks>Returnere nødvendige opplysninger om aktiv fastlegeforhold til en innbygger</remarks>
        /// <param name="patientNin">Referanse ID til innbygger-objektet (fødselsnummer/D-nummer)</param>
        /// <value></value>
        /// <returns>Sammensatt liste med detaljer over innbyggerens aktiv fastlege med relevante objekter (fastlege-objekt/behandlingssted-objekt/Gyldighetsperiode)</returns>
        /// <example>
        /// <code>
        /// var patientGP = flrReadService.GetPatientGPDetails(patientNin);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPDetails GetPatientGPDetails(string patientNin);

        /// <summary>
        /// Henter fastlegebytte historikken
        /// </summary>
        /// <remarks>Henter pasientens fastlege og all historikk som er knyttet til fastlegebytter i fortiden.</remarks>
        /// <param name="patientNin">Referanse ID til innbygger-objektet (fødselsnummer/D-nummer)</param>
        /// <value></value>
        /// <returns>Liste over alle innbyggerens fastlegeavtaler</returns>
        /// <example>
        /// <code>
        /// var patientGPHistoryList = flrReadService.GetPatientGPHistory(patientNin);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<PatientToGPContractAssociation> GetPatientGPHistory(string patientNin);

        /// <summary>
        /// Henter en enkelt fastlegeavtale
        /// </summary>
        /// <remarks>Metode for å hente ut en enkel fastlegeavtale</remarks>
        /// <param name="gpContractId">Kontraktens id.</param>
        /// <value></value>
        /// <returns>En fastlegeavtale</returns>
        /// <example>
        /// <code>
        /// var gpContract = flrReadService.GetGPContract(gpContractId);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPContract GetGPContract(long gpContractId);

        /// <summary>
        /// Henter fastlegeavtaler tilknyttet virksomheten.
        /// </summary>
        /// <remarks>
        /// Metoden som henter alle aktive fastlegelister som er knyttet til et behandlingssted på et gitt tidspunkt. 
        /// Hvis tidspunktet er NULL, så returneres alle kontrakter inklusive historiske.
        /// </remarks>
        /// <param name="organizationNumber">Legekontor orgnummer</param>
        /// <param name="atTime">Hent kontrakter for dette tidspunktet. NULL for historiske.</param>
        /// <value></value>
        /// <returns>Objekt med liste av fastlegelister tilknyttet gitt behandlingssted</returns>
        /// <example>
        /// <code>
        /// //For et gitt tidspunkt
        /// var atTime = DateTime.Now;
        /// var contractsOnOfficeList = flrReadService.GetGPContractsOnOffice(organizationNumber, atTime);
        /// //Alle kontrakter også historiske
        /// var contractsOnOfficeList = flrReadService.GetGPContractsOnOffice(organizationNumber, null);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<GPContract> GetGPContractsOnOffice(int organizationNumber, DateTime? atTime);

        /// <summary>
        /// Henter fastlegeliste.
        /// </summary>
        /// <remarks>Henter alle innbyggere på fastlegens liste over pasienter på hentetidspunktet.</remarks>
        /// <param name="gpContractId">Id til fastlegens kontrakt.</param>
        /// <value></value>
        /// <returns>Liste over aktuelle innbyggere på fastlegens pasientliste</returns>
        /// <example>
        /// <code>
        /// var gpPatientList = flrReadService.GetGPPatientList(gpContractId);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<PatientToGPContractAssociation> GetGPPatientList(long gpContractId);

        /// <summary>
        /// Henter fastlege og tilhørende praksis(er)
        /// </summary>
        /// <remarks>Informasjon om fastlege og tilhørende fastlegepraksis</remarks>
        /// <param name="hprNumber">Legens HPR-nummer. Må være høyere enn 0</param>
        /// <param name="atTime">Hvis null, historiske og framtidige. Hvis satt, kun kontrakter relevant på det tidspunkt.</param>
        /// <value></value>
        /// <returns>Fastlegeavtaler som er tilknyttet til samme en lege</returns>
        /// <example>
        /// <code>
        /// //For et gitt tidspunkt
        /// var atTime = DateTime.Now;
        /// var gpDetail = flrReadService.GetGPWithAssociatedGPContracts(hprNumber, atTime);
        /// var contractsList = gpDetail.Contracts;
        /// 
        /// //Alle kontrakter også historiske
        /// var gpDetail = flrReadService.GetGPWithAssociatedGPContracts(hprNumber, null);
        /// var contractsList = gpDetail.Contracts;
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPDetails GetGPWithAssociatedGPContracts(int hprNumber, DateTime? atTime);

        /// <summary>
        /// Sjekker om en lege er pasientens fastlege på et gitt tidspunkt
        /// </summary>
        /// <param name="patientNin"></param>
        /// <param name="hprNumber">Legens HPR-nummer.</param>
        /// <param name="atTime">Hvis null, akkurat nå. Hvis satt, sjekk om legen var fastlege på det tidspunkt.</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        bool ConfirmGP(string patientNin, int hprNumber, DateTime? atTime);
    }
}
