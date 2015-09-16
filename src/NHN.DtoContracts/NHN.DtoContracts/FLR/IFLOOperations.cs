using NHN.DtoContracts.Common.en;
using System.Collections.Generic;

namespace NHN.DtoContracts.FLR
{
    public interface IFLOOperations
    {
        // --------------------------
        // Fastlegeavtale
        // --------------------------

        //OpprettFastlegeavtale
        void CreateGPContract(GPContract newGPContract);


        //OppdaterFastlegeavtale
        void UpdateGPContract(GPContract gpContract);


        //OppdaterFastlegeavtaleMaksAntall
        void UpdateGPContractMaxPatients(int gpContractId, int maxPatients);

        //SettFastlegeListeStatus
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
