using NHN.DtoContracts.Common.en;
using System.Collections.Generic;
using System.ServiceModel;

namespace NHN.DtoContracts.Flr
{
    /// <summary>
    /// Skriveoperasjoner til FLR. Eneste bruker er FLO p.t.
    /// </summary>
    [ServiceContract(Namespace = FlrXmlNamespace.V1)]
    public interface IFlrWriteOperations
    {
        /// <summary>
        /// Lag en mengde historiske bedrifter. Historiske bedrifter er Business-objekter med et negativt organisasjonsnummer for å skille dem fra bedrifter med gyldige, faktiske organisasjonsnummer.
        /// Den eneste feltene i det innkommende Business objektet som skal være satt er:
        /// OrganizationName, PhysicalAddreses, ElectronicAddresses, Name, DisplayName, Valid
        /// Alle andre datafelter må være null/0.
        /// </summary>
        /// <param name="businesses">Listen over bedrifter man ønsker lage.</param>
        /// <returns>ID'er til opprettede business'es. Den returnerte arrayen mapper 1-1 til business parameteren. Dvs business[i]'s ID vil komme i ret[i]. Dette vil være _negative_ nummer.</returns>
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


        /// <summary>
        /// Oppretter en ny fastlegeavtale
        /// </summary>
        /// <param name="newGPContract"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPContract(GPContract newGPContract);

        /// <summary>
        /// Oppretter en ny fastlegeavtale - importversjon
        /// </summary>
        /// <param name="bulkGPContracts"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPContractBulk(List<GPContract> bulkGPContracts);


        /// <summary>
        /// Oppdaterere en fastlegeavtale
        /// </summary>
        /// <param name="gpContract"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPContract(GPContract gpContract);
        

        /// <summary>
        /// Setter maks antall pasienter på en fastlegeliste.
        /// </summary>
        /// <param name="gpContractId"></param>
        /// <param name="maxPatients"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPContractMaxPatients(long gpContractId, int maxPatients);


        /// <summary>
        /// Oppdaterer status på en GPContract
        /// </summary>
        /// <param name="gpContractId"></param>
        /// <param name="status"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPContractStatus(long gpContractId, Code status); //Kun tillate Åpne, Lukke 


        // --------------------------
        // Utekontor 
        // --------------------------

        /// <summary>
        /// Oppretter et utekontor
        /// </summary>
        /// <param name="office">Utekontordata</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateOutOfOfficeLocation(OutOfOfficeLocation office);


        /// <summary>
        /// Oppdatererer et utekontor
        /// </summary>
        /// <param name="office"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateOutOfOfficeLocation(OutOfOfficeLocation office);

        /// <summary>
        /// Fjerner et utekontor. Dette er det samme som å sette utekontoret til utløpt.
        /// </summary>
        /// <param name="outOfOfficeId"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void RemoveOutOfOfficeLocation(long outOfOfficeId);

        /// <summary>
        /// Oppretter en kontraktsperiode for en lege på en GPContract
        /// </summary>
        /// <param name="association"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPOnContractAssociation(GPOnContractAssociation association);


        /// <summary>
        /// Oppretter en kontraktsperiode for en lege på en GPContract - importversjon
        /// </summary>
        /// <param name="creates"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPOnContractAssociationBulk(List<GPOnContractAssociation> creates);


        /// <summary>
        /// Oppdaterer en kontraktsperiode for en lege på en GPContract
        /// </summary>
        /// <param name="association"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPOnContractAssociation(GPOnContractAssociation association);

        // --------------------------
        // LegeSprak 
        // --------------------------

        /// <summary>
        /// Oppdaterer listen over språk en lege kan snakke.
        /// </summary>
        /// <param name="hprNumber"></param>
        /// <param name="languages"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPLanguages(int hprNumber, ICollection<Code> languages);


        // --------------------------
        // ListeTilhorighet
        // --------------------------

        /// <summary>
        /// Kobler en pasient til en fastlegeliste.
        /// </summary>
        /// <param name="patientToGPContractAssociation"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreatePatientToGPContractAssociation(PatientToGPContractAssociation patientToGPContractAssociation);

        /// <summary>
        /// Kobler en pasient til en fastlegeliste - importversjon
        /// </summary>
        /// <param name="patientToGPContractAssociation"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreatePatientToGPContractAssociationBulk(List<PatientToGPContractAssociation> patientToGPContractAssociation);

        /// <summary>
        /// Flytter en innbyger fra en liste til en annen.
        /// </summary>
        /// <param name="fromGPContract">ID til fastlegeliste en innbygger skal flyttes FRA.</param>
        /// <param name="patientsToMove"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void MovePatients(long fromGPContract, ICollection<PatientToGPContractAssociation> patientsToMove);

        /// <summary>
        /// AvsluttFastlegeavtaleOgFlyttInnbyggere  
        /// </summary>
        /// <param name="gpContractId"></param>
        /// <param name="listStatus"></param>
        /// <param name="period"></param>
        /// <param name="capitaToMove"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CancelGPContractAndMovePatients(long gpContractId, Code listStatus, Period period, ICollection<PatientToGPContractAssociation> capitaToMove);

        /// <summary>
        /// AvsluttInnbyggerPåListe.
        /// Skal FLR gjøre sjekk her ? Tentativt. JA! (F.eks ikke sette status Slettet dersom listen har aktive pasienter.) 
        /// </summary>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CancelPatientOnGPContract(long gpContractId, string patientNin, Code lastChangeCode);

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
