using NHN.DtoContracts.Common.en;
using System.Collections.Generic;
using System.ServiceModel;

namespace NHN.DtoContracts.Flr
{
    [ServiceContract(Namespace = FlrXmlNamespace.V1)]
    public interface IFlrFloOperations
    {
        // --------------------------
        // Fastlegeavtale
        // --------------------------

        //OpprettFastlegeavtale
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPContract(GPContract newGPContract);


        //OppdaterFastlegeavtale
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPContract(GPContract gpContract);


        //OppdaterFastlegeavtaleMaksAntall
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPContractMaxPatients(int gpContractId, int maxPatients);

        //SettFastlegeListeStatus
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPContractStatus(int gpContractId, Code status); //Kun tillate Åpne, Lukke 


        // --------------------------
        // Utekontor 
        // --------------------------

        //OpprettUtekontor
        void CreateOutOfOfficeOffice(int practitionerAgreementIdFlo, OutOfOfficeOffice office);

        //OppdaterUtekontor
        void UpdateOutOfOfficeOffice(int practitionerAgreementIdFlo, OutOfOfficeOffice office);

        //Fjerne utekontor 
        void RemoveOutOfOfficeOffice(OutOfOfficeOffice office);
        // --------------------------
        // Legeperiode
        // --------------------------

        //OpprettLegePeriode
        void CreateGPOnContractAssociation(int gpContractId, GPOnContractAssociation association);

        //OppdaterLegePeriode
        void UpdateGPOnContractAssociation(int gpContractid, GPOnContractAssociation association);

        // --------------------------
        // LegeSprak 
        // --------------------------

        //OppdaterLegeSprak
        void UpdateGPLanguages(int hprNumber, ICollection<Code> languages);  //Alle språk sendes hver gang


        // --------------------------
        // ListeTilhorighet
        // --------------------------

        //OpprettListeTilhorighet
        void CreatePatientToGPContractAssociation(PatientToGPContractAssociation patientToGPContractAssociation);

        //FlyttInnbyggereOperasjon
        void MovePatient(int fromGPContract, ICollection<PatientToGPContractAssociation> patientsToMove);


        /// <summary>
        /// AvsluttFastlegeavtaleOgFlyttInnbyggere  
        /// </summary>
        /// <param name="gpContractId"></param>
        /// <param name="listStatus"></param>
        /// <param name="period"></param>
        /// <param name="capitaToMove"></param>
        void CancelGPContractAndMovePations(int gpContractId, Code listStatus, Period period, ICollection<PatientToGPContractAssociation> capitaToMove);

        /// <summary>
        /// AvsluttInnbyggerPåListe.
        /// Skal FLR gjøre sjekk her ? Tentativt. JA! (F.eks ikke sette status Slettet dersom listen har aktive pasienter.) 
        /// </summary>
        void CancelPatientOnGPContract(int gpContractId, string patientNationalId, Code lastChangeCode); 
    }
}
