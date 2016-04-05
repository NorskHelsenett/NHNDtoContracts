using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using System;
using NHN.DtoContracts.Flr.Data;
using NHN.DtoContracts.Htk;
using System.IO;

namespace NHN.DtoContracts.Flr.Service
{
    /// <summary>
    /// Leseoperasjoner for FLR (GP v2)
    /// </summary>
    /// <permission>
    /// Tillater ikke anonyme brukere
    /// </permission>
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
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig</exception>
        /// <example>
        /// <code>
        /// var patientGP = flrReadService.GetPatientGPDetails(patientNin);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR, FLR_READ eller FLR_LOOKUP
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PatientToGPContractAssociation GetPatientGPDetails(string patientNin);

        /// <summary>
        /// Henter fastleger for en liste med personer
        /// </summary>
        /// <param name="patientNins">Liste over pasienter</param>
        /// <returns>PatientToGPContractAssociation</returns>
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis en pasients ikke har en fastlegekobling</exception>
        /// <example>
        /// <code>
        /// var patientGPAssociationList = flrReadService.GetPatientsGPDetails(listOfPatientNins);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR, FLR_READ eller FLR_LOOKUP
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<PatientToGPContractAssociation> GetPatientsGPDetails(string[] patientNins);

        /// <summary>
        /// Henter fastlegen på et gitt tidspunkt per pasient for en liste med pasienter.
        /// </summary>
        /// <param name="patientNins">Liste over pasienter og tidspunktet en ønsker informasjon om pasienten på.</param>
        /// <remarks>Hvis noen av personene ikke eksisterer i FLR/ikke har noen lege på tidspunktet vil de ikke finnes i resultatsettet.</remarks>
        /// <returns>Usortert liste over pasienter-til-kontrakt assiosasjoner.</returns>
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig</exception>
        /// <example>
        /// <code language="C#">
        /// var patients = GetPatientsGPDetailsAtTime(new [] { new NinWithTimestamp("10109012345", new DateTime(1999,2,3)) });
        /// if (patients.Length > 0) 
        /// {
        ///     foreach (var patientAssoc in patients)
        ///     {
        ///         var gps = string.Join(", ", patientAssoc.DoctorCycles.Select(dc => $"#{dc.HprNumber}: {dc.GP.FirstName} {dc.GP.MiddleName} {dc.GP.LastName}"));
        ///         Console.WriteLine($"{patientAssoc.PatientNIN}: ContractID: {patientAssoc.GPContractId} GP(s): {gps}");
        ///     }
        /// }
        /// else 
        /// {
        ///    Console.WriteLine("Pasienten har ingen fastlege på tidspunktet");
        /// }
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR, FLR_READ eller FLR_LOOKUP
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<PatientToGPContractAssociation> GetPatientsGPDetailsAtTime(NinWithTimestamp[] patientNins);

        /// <summary>
        /// Henter fastlegebytte historikken
        /// </summary>
        /// <remarks>Henter pasientens fastlege og all historikk som er knyttet til fastlegebytter i fortiden.</remarks>
        /// <param name="patientNin">Referanse ID til innbygger-objektet (fødselsnummer/D-nummer)</param>
        /// <param name="includePatientData">
        /// Hvorvidt personopplysinger om pasient skal hentes opp. Dette vil føre til redusert ytelse, 
        /// så ikke bruk hvis du allerede har opplysningene.
        /// </param>
        /// <returns>Liste over alle innbyggerens fastlegeavtaler</returns>
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis en person ikke har noen fastlege</exception>
        /// <example>
        /// <code>
        /// var patientGPHistoryList = flrReadService.GetPatientGPHistory(patientNin);
        /// </code>
        /// </example>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<PatientToGPContractAssociation> GetPatientGPHistory(string patientNin, bool includePatientData);

        /// <summary>
        /// Henter en enkelt fastlegeavtale
        /// </summary>
        /// <remarks>Metode for å hente ut en enkel fastlegeavtale</remarks>
        /// <param name="gpContractId">Kontraktens id.</param>
        /// <returns>En fastlegeavtale</returns>
        /// <exception cref="ArgumentException">Kastes hvis en kontrakt ikke finnes</exception>
        /// <example>
        /// <code>
        /// var gpContract = flrReadService.GetGPContract(gpContractId);
        /// </code>
        /// </example>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ
        /// </permission>
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
        /// <returns>Objekt med liste av fastlegelister tilknyttet gitt behandlingssted</returns>
        /// <exception cref="ArgumentException">Kastes hvis et ugyldig organisasjonsnummer er gitt</exception>
        /// <exception cref="ArgumentException">Kastes hvis en virksomhet ikke har noen fastlegeavtaler</exception>
        /// <example>
        /// <code>
        /// //For et gitt tidspunkt
        /// var atTime = DateTime.Now;
        /// var contractsOnOfficeList = flrReadService.GetGPContractsOnOffice(organizationNumber, atTime);
        /// //Alle kontrakter også historiske
        /// var contractsOnOfficeList = flrReadService.GetGPContractsOnOffice(organizationNumber, null);
        /// </code>
        /// </example>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<GPContract> GetGPContractsOnOffice(int organizationNumber, DateTime? atTime);

        /// <summary>
        /// Henter fastlegeliste.
        /// </summary>
        /// <remarks>Henter alle innbyggere på fastlegens liste over pasienter på hentetidspunktet.</remarks>
        /// <param name="gpContractId">Id til fastlegens kontrakt.</param>
        /// <returns>Liste over aktuelle innbyggere på fastlegens pasientliste</returns>
        /// <exception cref="ArgumentException">Kastes hvis kontraktens id ikke er høyere enn 0</exception>
        /// <exception cref="ArgumentException">Kastes hvis en kontrakt ikke finnes</exception>
        /// <exception cref="ArgumentException">Kastes hvis en kontrakt er assosiert med en enhet uten orgnummer</exception>
        /// <exception cref="ArgumentException">Kastes hvis en liste ikke kan utleveres</exception>
        /// <example>
        /// <code>
        /// var gpPatientList = flrReadService.GetGPPatientList(gpContractId);
        /// </code>
        /// </example>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<PatientToGPContractAssociation> GetGPPatientList(long gpContractId);

        /// <summary>
        /// Henter fastlege og tilhørende praksis(er)
        /// </summary>
        /// <remarks>Informasjon om fastlege og tilhørende fastlegepraksis</remarks>
        /// <param name="hprNumber">Legens HPR-nummer. Må være høyere enn 0</param>
        /// <param name="atTime">Hvis null, historiske og framtidige. Hvis satt, kun kontrakter relevant på det tidspunkt.</param>
        /// <returns>Fastlegeavtaler som er tilknyttet til samme en lege</returns>
        /// <exception cref="ArgumentException">Kastes hvis en leges hpr-nummer ikke er registrert som fastlege</exception>
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
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPDetails GetGPWithAssociatedGPContracts(int hprNumber, DateTime? atTime);

        /// <summary>
        /// Sjekker om en lege er pasientens fastlege på et gitt tidspunkt
        /// </summary>
        /// <param name="patientNin"></param>
        /// <param name="hprNumber">Legens HPR-nummer.</param>
        /// <param name="atTime">Hvis null, akkurat nå. Hvis satt, sjekk om legen var fastlege på det tidspunkt.</param>
        /// <returns>Sant hvis en lege er pasientens fastlege</returns>
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis hpr nummer er ugyldig</exception>
        /// <example>
        /// <code>
        /// //For et gitt tidspunkt
        /// var atTime = DateTime.Now;
        /// var isConfirmedGP = flrReadService.ConfirmGP(patientNin,hprNumber, atTime);
        /// 
        /// //Alle kontrakter også historiske
        /// var isConfirmedGP = flrReadService.ConfirmGP(patientNin,hprNumber, null);
        /// </code>
        /// </example>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        bool ConfirmGP(string patientNin, int hprNumber, DateTime? atTime);

        /// <summary>
        /// Denne operasjonen er kun tilgjengelig for NAV. For å hente fastlegeliste med pasienter basert på personnummer til legen og kommune.
        /// </summary>
        /// <param name="doctorNin">Legens personnummer</param>
        /// <param name="municipalityNr">Kommune fastlegelisten gjelder</param>
        /// <param name="doSubstituteSearch">Hvorvidt legen kan være en vikar. Hvis ikke søker vi utelukkende på legen.</param>
        /// <returns>GPContract funnet. På kontrakten vil PatientList være fyllt ut.</returns>
        /// <exception cref="ArgumentException">Kastes hvis kommunenr er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis personnummer er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis aktive fastlegelister i gitt kommune er funnet</exception>
        /// <exception cref="ArgumentException">Kastes hvis det mer en en aktiv legeperiode</exception>
        /// <example>
        /// <code>
        /// var contract = flrReadService.GetGPContractForNav(doctorNin,municipalityNr, doSubstituteSearch);
        /// </code>
        /// </example>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ_EXTENDED
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPContract GetGPContractForNav(string doctorNin, string municipalityNr, bool doSubstituteSearch);

        /// <summary>
        /// Returnerer pasientlister på gammelt kith/nav format. Se <see cref="NavEncryptedPatientListParameters"/> for inputinfo. MERK: Metoden returnerer IKKE KRYPTERTE data per dags dato.
        /// </summary>
        /// <param name="param">Parametre for uttrek</param>
        /// <returns>Kryptert stream.</returns>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ_EXTENDED
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Stream NavGetEncryptedPatientList(NavEncryptedPatientListParameters param);

        /// <summary>
        /// Returnerer pasientlister på gammelt kith/nav format. Se <see cref="NavEncryptedPatientListParameters"/> for beskrivelse av de faktiske parameterene. MERK: Metoden returnerer IKKE KRYPTERTE data per dags dato.
        /// </summary>
        /// <param name="doctorNIN">Se <see cref="NavEncryptedPatientListParameters"/></param>
        /// <param name="municipalityId">Se <see cref="NavEncryptedPatientListParameters"/></param>
        /// <param name="encryptWithX509Certificate">Se <see cref="NavEncryptedPatientListParameters"/></param>
        /// <param name="month">Se <see cref="NavEncryptedPatientListParameters"/></param>
        /// <param name="doSubstituteSearch">Se <see cref="NavEncryptedPatientListParameters"/></param>
        /// <param name="senderXml">Se <see cref="NavEncryptedPatientListParameters"/></param>
        /// <param name="receiverXml">Se <see cref="NavEncryptedPatientListParameters"/></param>
        /// <param name="listType">Se <see cref="NavEncryptedPatientListParameters"/></param>
        /// <returns></returns>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ_EXTENDED
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Stream NavGetEncryptedPatientListAlternate(string doctorNIN, string municipalityId, byte[] encryptWithX509Certificate, DateTime month, bool doSubstituteSearch, string senderXml, string receiverXml, string listType);

        /// <summary>
        /// Hent ut alle GPContractId's på kontrakter hvis legekontor har et postnummer som er lik eller begynner på postNr.
        /// </summary>
        /// <param name="postNr">Postnummer eller starten av postnummer. Dvs. at postNr.Lenght må være 2, 3 eller 4.</param>
        /// <returns>Liste over alle aktive GPContracts.Id hvis legekontor har en besøksadresse (RES/FLO_RES) som begynner med </returns>
        /// <exception cref="ArgumentException">Kastes hvis postnr er feil</exception>
        /// <exception cref="ArgumentException">Kastes hvis postnr ikke er på 2 eller 4 tegn</exception>
        /// <example>
        /// <code>
        /// var contractIdList = flrReadService.GetGPContractIdsOperatingInPostalCode(postnr);
        /// </code>
        /// </example>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<long> GetGPContractIdsOperatingInPostalCode(string postNr);

        /// <summary>
        /// Search for GP.
        /// Dersom du ønsker å søke etter legekontor, gå på HTK tjenesten.
        /// </summary>
        /// <remarks>Søk etter leger</remarks>
        /// <param name="searchParameters">Søkeparametere for det tilhørende søk</param>
        /// <returns>Paginert liste med  leger basert på søkeparametetere</returns>
        /// <exception cref="ArgumentException">Kastes hvis feil søkeparameter er oppgitt</exception>
        /// <example>
        /// <code>
        /// //For et gitt tidspunkt
        /// var searchResult = flrReadService.SearchForGP(searchCriteria);
        /// </code>
        /// </example>       
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PagedResult<GPDetails> SearchForGP(GPSearchParameters searchParameters);

        /// <summary>
        /// Henter pasientlister i gammelt NAV fil-format. 
        /// Streamen er ZipArchive
        /// </summary>
        /// <param name="parameters">Bestemmer hva som skal hentes, og i hviklket format</param>
        /// <returns>ZipArchive Stream</returns>      
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR, FLR_READ_ALL_PATIENTS eller ADRESSEREGISTER_ADMINISTRATOR
        /// ADRESSEREGISTER_ADMINISTRATOR rollen må også være knyttet til Unit som kontrakten er knyttet til
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Stream GetNavPatientLists(GetNavPatientListsParameters parameters);
    }
}
