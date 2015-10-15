using NHN.DtoContracts.Common.en;
using System.Collections.Generic;
using System.ServiceModel;

namespace NHN.DtoContracts.Flr
{
    [ServiceContract(Namespace = FlrXmlNamespace.V1)]
    public interface IFlrWriteOperations
    {
        // --------------------------
        // Fastlegeavtale
        // --------------------------

        //OpprettFastlegeavtale
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPContract(GPContract newGPContract);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPContractBulk(List<GPContract> bulkGPContracts);


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
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateOutOfOfficeLocation(int gpContractId, OutOfOfficeLocation office);


        //OppdaterUtekontor
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateOutOfOfficeLocation(int gpContractId, OutOfOfficeLocation office);

        //Fjerne utekontor 
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void RemoveOutOfOfficeLocation(OutOfOfficeLocation office);
        
        // --------------------------
        // Legeperiode
        // --------------------------

        //OpprettLegePeriode
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPOnContractAssociation(int gpContractId, GPOnContractAssociation association);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPOnContractAssociationBulk(List<CreateGPOnContractAssociationBulk> creates);


        //OppdaterLegePeriode
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPOnContractAssociation(int gpContractId, GPOnContractAssociation association);

        // --------------------------
        // LegeSprak 
        // --------------------------

        //OppdaterLegeSprak
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPLanguages(int hprNumber, ICollection<Code> languages);  //Alle språk sendes hver gang


        // --------------------------
        // ListeTilhorighet
        // --------------------------

        //OpprettListeTilhorighet
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreatePatientToGPContractAssociation(PatientToGPContractAssociation patientToGPContractAssociation);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreatePatientToGPContractAssociationBulk(List<PatientToGPContractAssociation> patientToGPContractAssociation);


        //FlyttInnbyggereOperasjon
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void MovePatients(int fromGPContract, ICollection<PatientToGPContractAssociation> patientsToMove);


        /// <summary>
        /// AvsluttFastlegeavtaleOgFlyttInnbyggere  
        /// </summary>
        /// <param name="gpContractId"></param>
        /// <param name="listStatus"></param>
        /// <param name="period"></param>
        /// <param name="capitaToMove"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CancelGPContractAndMovePatients(int gpContractId, Code listStatus, Period period, ICollection<PatientToGPContractAssociation> capitaToMove);

        /// <summary>
        /// AvsluttInnbyggerPåListe.
        /// Skal FLR gjøre sjekk her ? Tentativt. JA! (F.eks ikke sette status Slettet dersom listen har aktive pasienter.) 
        /// </summary>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CancelPatientOnGPContract(int gpContractId, string patientNin, Code lastChangeCode); 
    }
}
