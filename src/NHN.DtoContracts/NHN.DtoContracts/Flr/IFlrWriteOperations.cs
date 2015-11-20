using NHN.DtoContracts.Common.en;
using System.Collections.Generic;
using System.ServiceModel;

namespace NHN.DtoContracts.Flr
{
    [ServiceContract(Namespace = FlrXmlNamespace.V1)]
    public interface IFlrWriteOperations
    {
        /// <summary>
        /// Create a bunch of historical businesses. The returned array maps one to one with the provided businesses. The orgnumber of the provided businesses must be null.
        /// The only accepted data is:
        /// OrganizationName, PhysicalAddreses, ElectronicAddresses,
        /// All other data must be null.
        /// </summary>
        /// <param name="businesses"></param>
        /// <returns>ID'er til opprettede business'es. Den returnerte arrayen mapper 1-1 til business parameteren. Dvs business[i]'s ID vil komme i ret[i].</returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        int[] CreateHistoricalBusinessBulk(Business[] businesses);

        /// <summary>
        /// Dekker både create/update.
        /// resFlo.Type MÅ være RES_FLO.
        /// </summary>
        /// <param name="organizationNumber"></param>
        /// <param name="resFlo"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void SetCustomFloAddress(int organizationNumber, PhysicalAddress resFlo);

        /// <summary>
        /// Oppdater elektroniske adresser for en GPOffice
        /// For å slette en adresse, sett alle elementer i ElectronicAddres bortsett fra .Type til NULL/0.
        /// </summary>
        /// <param name="organizationNumber"></param>
        /// <param name="electronicAddresses"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void SetElectronicAddresses(int organizationNumber,  ICollection<ElectronicAddress> electronicAddresses);

        /// <summary>
        /// Fjern RES_FLO adresse på en organisasjonsenhet.
        /// </summary>
        /// <param name="organizationNumber"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void DeleteCustomFloAddressOnGPOffice(int organizationNumber);

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
        void CreateOutOfOfficeLocation(OutOfOfficeLocation office);


        //OppdaterUtekontor
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateOutOfOfficeLocation(OutOfOfficeLocation office);

        //Fjerne utekontor 
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void RemoveOutOfOfficeLocation(int outOfOfficeId);
        
        // --------------------------
        // Legeperiode
        // --------------------------

        //OpprettLegePeriode
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPOnContractAssociation(GPOnContractAssociation association);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPOnContractAssociationBulk(List<GPOnContractAssociation> creates);


        //OppdaterLegePeriode
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPOnContractAssociation(GPOnContractAssociation association);

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

        /// <summary>
        /// Brukes for å sette visningsnavnet på et legekontor. Merk at legekontoret selv kan overskrive det som eventuelt settes her selv.
        /// </summary>
        /// <param name="organizationNumber">Organisasjonsnummer til legekontoret</param>
        /// <param name="displayName">Visningsnavnet man ønsker sette. Maks 150 tegn.</param>
        [OperationContract]
        [FaultContract(typeof (GenericFault))]
        void SetDisplayNameOnGPOffice(int organizationNumber, string displayName);
    }
}
