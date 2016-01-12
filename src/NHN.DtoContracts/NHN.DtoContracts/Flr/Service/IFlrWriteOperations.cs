using System;
using NHN.DtoContracts.Common.en;
using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Flr.Data;
using NHN.DtoContracts.Htk;

namespace NHN.DtoContracts.Flr.Service
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
        /// Sette en alternativ besøksadresse fra FLO enn den som er registrert i andre autorative registre
        /// </summary>
        /// <remarks>Registrere egen type av besøksadresse som er unik for FLO. Benyttes for opprettelse og oppdatering av denne type adresse.</remarks>
        /// <param name="organizationNumber">Referanse til virksomhet i Bedriftsregister</param>
        /// <param name="resFlo">Type MÅ være RES_FLO. Generisk objekt for fysisk adressetype</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// //physicalAddresse.Type.CodeValue = RES_FLO
        /// flrWriteService.SetCustomFloAddress(organizationNumber, physicalAddresse);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void SetCustomFloAddress(int organizationNumber, PhysicalAddress resFlo);

        /// <summary>
        /// Registrere/oppdatere elektroniske adresse av type adressekomponenter. Kan også benyttes til sletting av adresser.
        /// </summary>
        /// <remarks>For å slette en adresse, sett alle elementer i ElektroniskeAdresser bortsett fra .Type til NULL/0.</remarks>
        /// <param name="organizationNumber">Referanse til virksomhet i Bedriftsregister</param>
        /// <param name="electronicAddresses">Liste av elektroniske kontakmuligheter som er koblet til en virksomhet</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// //For å legge til eller endre en elektroniskadresse
        /// flrWriteService.SetElectronicAddresses(organizationNumber, electronicAddresses);
        /// 
        /// //For å slette tilhørende elektroniskeadresse. Sett kun type og alt annet til null på den som skal slettes
        /// // electronicAddresses.Type.CodeValue = ElectronicAddressType.Telephone
        /// // electronicAddresses.Address = null
        /// flrWriteService.SetElectronicAddresses(organizationNumber, electronicAddresses);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void SetElectronicAddresses(int organizationNumber,  ICollection<ElectronicAddress> electronicAddresses);

        /// <summary>
        /// Slette overflødig besøksadresse (RES_FLO) fra virksomheten.
        /// </summary>
        /// <remarks></remarks>
        /// <param name="organizationNumber">Referanse til virksomhet i Bedriftsregister</param>
        /// <value></value>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Kastes når en organisasjonsenhet med angitt organisasjonsnummer ikke har en besøksadresse for fastlegeordningen</exception>
        /// <example>
        /// <code>
        /// flrWriteService.DeleteCustomFloAddressOnGPOffice(organizationNumber);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void DeleteCustomFloAddressOnGPOffice(int organizationNumber);

        /// <summary>
        /// Opprette en ny fastlegeavtale slik at ny fastlegeliste med relevante attributter blir etablert i registerplattform
        /// </summary>
        /// <remarks>
        /// Opprette avtalen mellom en lege og kommune.
        /// Det forutsettes at lege finnes allerede fra før i HPR og at legen er tilknyttet en legekontor(TreatmentCenter) som finnes i Adresseregisteret/Bedriftsregisteret.</remarks>
        /// <param name="newGPContract">En ny legekontrakt</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.CreateGPContract(newGPContract);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPContract(GPContract newGPContract);

        /// <summary>
        /// Oppretter en ny fastlegeavtale - importversjon (se CreateGPContract)
        /// </summary>
        /// <seealso cref="CreateGPContract"/>
        /// <param name="bulkGPContracts"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPContractBulk(List<GPContract> bulkGPContracts);

        /// <summary>
        /// Oppdatere en eksisterende fastlegeavtale med nye opplysninger slik at fastlegeliste i registerplattform får oppdatert registrerte verdier
        /// </summary>
        /// <remarks>Benyttes for oppdatering/endring/avslutning av en eksisterende fastlegeavtale</remarks>
        /// <param name="gpContract">En eksisterende legekontrakt, som skal oppdateres</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.UpdateGPContract(gpContract);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPContract(GPContract gpContract);


        /// <summary>
        /// Oppdatering av listetak på en fastlegeavtale uten at andre verdier skal endre seg
        /// </summary>
        /// <remarks></remarks>
        /// <param name="gpContractId">Id på fastlegeavtalen</param>
        /// <param name="maxPatients">Listetak på en avtale</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.GetPatientGPDetails(gpContractId, maxPatients);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPContractMaxPatients(long gpContractId, int maxPatients);

        /// <summary>
        /// Oppdatering av listestatus uten endringer av andre verdier
        /// </summary>
        /// <remarks>Kun endring til statusene Åpne og Lukke</remarks>
        /// <param name="gpContractId">Id på fastlegeavtalen</param>
        /// <param name="status">Status på liste status med referanse til kodeverk</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.GetPatientGPDetails(gpContractId, status);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPContractStatus(long gpContractId, Code status); //Kun tillate Åpne, Lukke 


        // --------------------------
        // Utekontor 
        // --------------------------

        /// <summary>
        /// Oppretter et utekontor registrert på overordnet fastlegepraksis/avtale
        /// </summary>
        /// <remarks>Hvis et fastlegekontor har dislokerte behandlingssteder (utekontorer) så skal det kunne registreres på overordnet fastlegepraksis/avtale.</remarks>
        /// <param name="office">Utekontordata</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.CreateOutOfOfficeLocation(office);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateOutOfOfficeLocation(OutOfOfficeLocation office);

        /// <summary>
        /// Oppdatererer et utekontor
        /// </summary>
        /// <remarks>Oppdatering av opplysninger om et utekontor</remarks>
        /// <param name="office">Eksisterende utekontordata</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.UpdateOutOfOfficeLocation(office);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateOutOfOfficeLocation(OutOfOfficeLocation office);

        /// <summary>
        /// Fjerner et utekontor. Dette er det samme som å sette utekontoret til utløpt.
        /// </summary>
        /// <remarks>Sletter et utekontor fra liste over utekontorer.</remarks>
        /// <param name="outOfOfficeId">Id til utekontoret som skal slettes</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.RemoveOutOfOfficeLocation(outOfOfficeId);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void RemoveOutOfOfficeLocation(long outOfOfficeId);

		
	// --------------------------
        // Listetilhørighet 
        // --------------------------
		
        /// <summary>
        /// Oppretter en kontraktsperiode for en lege på en fastlegeavtale
        /// </summary>
        /// <remarks>Lager en lenke mellom lege i bestemt rolle til en fastlegeavtale</remarks>
        /// <param name="association">Koblingen for en periode legen er tilknyttet en fastlegeavtale</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.CreateGPOnContractAssociation(association);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPOnContractAssociation(GPOnContractAssociation association);


        /// <summary>
        /// Oppretter en kontraktsperiode for en lege på en GPContract - importversjon 
        /// </summary>
        /// <seealso cref="CreateGPOnContractAssociation"/>
        /// <remarks>Se CreateGPOnContractAssociation(GPOnContractAssociation association. Tar i mot en liste av koblinger.</remarks>
        /// <param name="creates"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreateGPOnContractAssociationBulk(List<GPOnContractAssociation> creates);

        /// <summary>
        /// Oppdatere eksisterende kobling mellom leger og eksisterende avtaler
        /// </summary>
        /// <remarks>Oppdaterer informasjonen mellom lege i bestemt rolle til en fastlegeavtale</remarks>
        /// <param name="association">Eksisterende koblingen for en periode legen er tilknyttet en fastlegeavtale</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.UpdateGPOnContractAssociation(association);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPOnContractAssociation(GPOnContractAssociation association);

		
		/// <summary>
        /// Sletter en kontraktsperiode for en lege på en GPContract
        /// </summary>
        /// <param name="gpOnContractAssociationId"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void DeleteGPOnContractAssociation(long gpOnContractAssociationId);
        // --------------------------
        // LegeSprak 
        // --------------------------

        /// <summary>
        /// Oppdaterer listen over språk en gitt lege kan snakke.
        /// </summary>
        /// <remarks>Registrerer språk på helsepersonell. En tom liste sletter alle språk på angitt helsepersonell.</remarks>
        /// <param name="hprNumber">Referanse id til helsepersonell</param>
        /// <param name="languages">Liste av språk med referanse til kodeverk (OID=3303 og OID=3301)</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// //For å sette språk
        /// flrWriteService.GetPatientGPDetails(UpdateGPLanguages, languages);
        /// 
        /// //For å slette alle registrerte språk
        /// flrWriteService.UpdateGPLanguages(hprNumber, emptyLanguagesList);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateGPLanguages(int hprNumber, ICollection<Code> languages);


        // --------------------------
        // ListeTilhorighet
        // --------------------------

        /// <summary>
        /// Kobler en pasient til en fastlegeliste.
        /// </summary>
        /// <remarks>Opprette nyregistrert person i PREG til en eksisterende fastlegeavtale i FLR</remarks>
        /// <param name="patientToGPContractAssociation">Kobling mellom innbygger og fastlegeavtale</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.CreatePatientToGPContractAssociation(patientToGPContractAssociation);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreatePatientToGPContractAssociation(PatientToGPContractAssociation patientToGPContractAssociation);

        /// <summary>
        /// Kobler en pasient til en fastlegeliste - importversjon
        /// </summary>
        /// <seealso cref="CreatePatientToGPContractAssociation"/>
        /// <remarks>Se CreatePatientToGPContractAssociation. Tar i mot en liste med koblinger for bulk operasjoner</remarks>
        /// <param name="patientToGPContractAssociation"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CreatePatientToGPContractAssociationBulk(List<PatientToGPContractAssociation> patientToGPContractAssociation);

        /// <summary>
        ///  Flytter en innbyger fra en liste til en annen.
        /// </summary>
        /// <remarks>Flytte pasienter mellom to fastlegelister. Fødselsnummer valideres. Feiler en pasient så kastes exception på alt.</remarks>
        /// <param name="fromGPContract">ID til fastlegeliste en innbygger skal flyttes FRA.</param>
        /// <param name="patientsToMove">Liste over innbyggere på eksisterende fastlegelister som skal flyttes</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.MovePatients(fromGPContract, patientsToMove);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void MovePatients(long fromGPContract, ICollection<PatientToGPContractAssociation> patientsToMove);

        /// <summary>
        /// Avslutter fastlegeavtale og flytter innbyggere  
        /// </summary>
        /// <remarks>Flytte alle pasienter mellom listene og deretter avslutter listen hvor innbyggere ble flyttet fra.</remarks>
        /// <param name="gpContractId">Referanse til fastlegeliste som skal avsluttes</param>
        /// <param name="listStatus">Referanse til kode for avsluttet status</param>
        /// <param name="period">Sluttdato på kontrakt</param>
        /// <param name="capitaToMove">Liste over innbyggere som skal flyttes til ny liste</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.CancelGPContractAndMovePatients(gpContractId, listStatus, period, capitaToMove);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CancelGPContractAndMovePatients(long gpContractId, Code listStatus, Period period, ICollection<PatientToGPContractAssociation> capitaToMove);

        /// <summary>
        /// Avslutte innbyggerens tilhørighet på en fastlegeliste/avtale
        /// </summary>
        /// <remarks></remarks>
        /// <param name="gpContractId">Referanse til fastlegelisten</param>
        /// <param name="patientNin">Referanse til innbyggerens fødselsnummer (eller D-nummer)</param>
        /// <param name="lastChangeCode">Referanse til kodeverk for avslutningskode</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.CancelPatientOnGPContract(patientNin);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CancelPatientOnGPContract(long gpContractId, string patientNin, Code lastChangeCode);

        /// <summary>
        /// Brukes for å sette visningsnavnet på et legekontor. Merk at legekontoret selv kan overskrive det som eventuelt settes her selv.
        /// </summary>
        /// <remarks></remarks>
        /// <param name="organizationNumber">Organisasjonsnummer til legekontoret</param>
        /// <param name="displayName">Visningsnavnet man ønsker sette. Maks 150 tegn.</param>
        /// <value></value>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// flrWriteService.SetDisplayNameOnGPOffice(organizationNumber, displayName);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof (GenericFault))]
        void SetDisplayNameOnGPOffice(int organizationNumber, string displayName);

        /// <summary>
        /// Sletter avtale, med ALLE relaterte relasjoner (Legeperioder, Tilhørigheter, Utekontor).
        /// Kun tilgjengelig i testmiljø.
        /// </summary>
        /// <param name="gpContractId">Id til fastlegeavtale.</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CleanupGPContract(long gpContractId);

        /// <summary>
        /// Sletter legekontorets avtaler, med ALLE relaterte relasjoner (Legeperioder, Tilhørigheter, Utekontor).
        /// Kun tilgjengelig i testmiljø.
        /// </summary>
        /// <param name="orgNr">Organisasjonsnummer til legekontoret.</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CleanupGPContractByOrgNr(int orgNr);

        /// <summary>
        /// Sletter legeperiode. 
        /// Kun tilgjengelig i testmiljø.
        /// </summary>
        /// <param name="gpOnContractAssociationId">Id til legeperiode.</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CleanupGPOnContractAssociation(long gpOnContractAssociationId);

        /// <summary>
        /// Sletter ALT om legen - Legeperioder, legespråk.
        /// Kun tilgjengelig i testmiljø.
        /// </summary>
        /// <param name="doctorHprNumber">HPR-nummer til legen.</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CleanupGP(int doctorHprNumber);

        /// <summary>
        /// Sletter legespråk.
        /// Kun tilgjengelig i testmiljø.
        /// </summary>
        /// <param name="doctorHprNumber">HPR-nummer til legen.</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CleanupGPLanguages(int doctorHprNumber);

        /// <summary>
        /// Sletter utekontor.
        /// Kun tilgjengelig i testmiljø.
        /// </summary>
        /// <param name="outOfOfficeId">Id til utekontor.</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CleanupOutOfOffice(long outOfOfficeId);

        /// <summary>
        /// Sletter tilhørighet.
        /// Kun tilgjengelig i testmiljø.
        /// </summary>
        /// <param name="patientToGPContractAssociation">Id til tilhørighet.</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CleanupPatientToGPContractAssociation(long patientToGPContractAssociation);

        /// <summary>
        /// Sletter samtlige entiteter i FLR innenfor et id-range med tilhørende relasjoner om de måtte treffe.
        /// Kun tilgjengelig i testmiljø.
        /// </summary>
        /// <param name="fromAndWithId">Fra og med Id.</param>
        /// <param name="toAndWithId">Til og med Id.</param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CleanupByIdSeed(long fromAndWithId, long toAndWithId);

        /// <summary>
        /// Sletter alt.
        /// Kun tilgjengelig i testmiljø.
        /// </summary>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void CleanupEverything();
    }
}
