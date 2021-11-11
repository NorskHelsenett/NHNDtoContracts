using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using System;
using NHN.DtoContracts.Flr.Data;
using System.IO;

namespace NHN.DtoContracts.Flr.Service
{
    /// <summary>
    /// Leseoperasjoner for FLR (GP v2)
    /// </summary>
    /// <remarks>
    /// Tillater ikke anonyme brukere
    /// </remarks>
    [ServiceContract(Namespace = Namespaces.FlrV1,
        Name = "IFlrReadOperations")]
    public interface IFlrReadOperations
    {
        /// <summary>
        /// Henter fastlege for en gitt person.
        /// </summary>
        /// <remarks>
        /// Returnere nødvendige opplysninger om aktiv fastlegeforhold til en innbygger.
        /// 
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// * FlrLookup
        /// </remarks>
        /// <param name="patientNin">Referanse ID til innbygger-objektet (fødselsnummer/D-nummer)</param>
        /// <returns>Sammensatt liste med detaljer over innbyggerens aktiv fastlege med relevante objekter (fastlege-objekt/behandlingssted-objekt/Gyldighetsperiode)</returns>
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig</exception>
        /// <example>
        /// <code>
        /// var patientGP = flrReadService.GetPatientGPDetails(patientNin);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PatientToGPContractAssociation GetPatientGPDetails(string patientNin);

        /// <summary>
        /// Henter fastleger for en liste med personer.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// * FlrLookup
        /// </remarks>
        /// <param name="patientNins">Liste over pasienter</param>
        /// <returns>PatientToGPContractAssociation</returns>
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis en pasients ikke har en fastlegekobling</exception>
        /// <example>
        /// <code>
        /// var patientGPAssociationList = flrReadService.GetPatientsGPDetails(listOfPatientNins);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<PatientToGPContractAssociation> GetPatientsGPDetails(string[] patientNins);

        /// <summary>
        /// Henter fastlegen på et gitt tidspunkt per pasient for en liste med pasienter.
        /// </summary>
        /// <param name="patientNins">Liste over pasienter og tidspunktet en ønsker informasjon om pasienten på.</param>
        /// <remarks>
        /// Hvis noen av personene ikke eksisterer i FLR/ikke har noen lege på tidspunktet vil de ikke finnes i resultatsettet.
        /// 
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// * FlrLookup
        /// </remarks>
        /// <returns>Usortert liste over pasienter-til-kontrakt assiosasjoner.</returns>
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig.</exception>
        /// <example>
        /// <code language="cs">
        /// var patientNins = new []
        /// {
        ///     new NinWithTimestamp("10109012345", new DateTime(1999, 2, 3))
        /// };
        /// var patients = GetPatientsGPDetailsAtTime(patientNins);
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
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<PatientToGPContractAssociation> GetPatientsGPDetailsAtTime(NinWithTimestamp[] patientNins);

        /// <summary>
        /// Henter historikk for fastlegebytter.
        /// </summary>
        /// <remarks>
        /// Henter pasientens fastlege og all historikk som er knyttet til fastlegebytter i fortiden.
        /// 
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// </remarks>
        /// <param name="patientNin">Referanse ID til innbygger-objektet (fødselsnummer/D-nummer)</param>
        /// <param name="includePatientData">
        /// Hvorvidt personopplysinger om pasient skal hentes opp.
        /// Dette vil føre til redusert ytelse, så ikke bruk hvis du allerede har opplysningene.
        /// </param>
        /// <returns>Liste over alle innbyggerens fastlegeavtaler</returns>
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis en person ikke har noen fastlege</exception>
        /// <example>
        /// <code>
        /// var patientGPHistoryList = flrReadService.GetPatientGPHistory(patientNin);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<PatientToGPContractAssociation> GetPatientGPHistory(string patientNin, bool includePatientData);

        /// <summary>
        /// Henter en enkelt fastlegeavtale.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// * FlrLookup
        /// </remarks>
        /// <param name="gpContractId">Kontraktens id.</param>
        /// <returns>En fastlegeavtale</returns>
        /// <exception cref="ArgumentException">Kastes hvis en kontrakt ikke finnes</exception>
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
        /// Metoden henter alle aktive fastlegelister som er knyttet til et behandlingssted på et gitt tidspunkt.
        /// Hvis tidspunktet er NULL returneres alle kontrakter inklusive historiske.
        /// 
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// </remarks>
        /// <param name="organizationNumber">Legekontor orgnummer</param>
        /// <param name="atTime">Hent kontrakter for dette tidspunktet. NULL for historiske.</param>
        /// <returns>Objekt med liste av fastlegelister tilknyttet gitt behandlingssted</returns>
        /// <exception cref="ArgumentException">Kastes hvis et ugyldig organisasjonsnummer er gitt</exception>
        /// <exception cref="ArgumentException">Kastes hvis en virksomhet ikke har noen fastlegeavtaler</exception>
        /// <example>
        /// <code language="cs">
        /// // For et gitt tidspunkt
        /// var atTime = DateTime.Now;
        /// var contractsOnOfficeList = flrReadService.GetGPContractsOnOffice(organizationNumber, atTime);
        /// 
        /// // Alle kontrakter, inkludert historiske
        /// var contractsOnOfficeList = flrReadService.GetGPContractsOnOffice(organizationNumber, null);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<GPContract> GetGPContractsOnOffice(int organizationNumber, DateTime? atTime);

        /// <summary>
        /// Henter fastlegeliste (alle innbyggere på fastlegens liste) over pasienter på hentetidspunktet.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead på Unit kontrakten er tilknyttet
        /// </remarks>
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
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<PatientToGPContractAssociation> GetGPPatientList(long gpContractId);

        /// <summary>
        /// Henter informasjon om fastlege og tilhørende fastlegepraksis(er)
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// </remarks>
        /// <param name="hprNumber">Legens HPR-nummer. Må være høyere enn 0</param>
        /// <param name="atTime">Hvis null, historiske og framtidige. Hvis satt, kun kontrakter relevant på det tidspunkt.</param>
        /// <returns>Fastlegeavtaler som er tilknyttet til samme en lege</returns>
        /// <exception cref="ArgumentException">Kastes hvis en leges hpr-nummer ikke er registrert som fastlege</exception>
        /// <example>
        /// <code langluage="C#">
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
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// </remarks>
        /// <param name="patientNin"></param>
        /// <param name="hprNumber">Legens HPR-nummer.</param>
        /// <param name="atTime">Hvis null, akkurat nå. Hvis satt, sjekk om legen var fastlege på det tidspunkt.</param>
        /// <returns>Sant hvis en lege er pasientens fastlege</returns>
        /// <exception cref="ArgumentException">Kastes hvis en pasients referanse id er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis hpr nummer er ugyldig</exception>
        /// <example>
        /// <code language="cs">
        /// //For et gitt tidspunkt
        /// var atTime = DateTime.Now;
        /// var isConfirmedGP = flrReadService.ConfirmGP(patientNin,hprNumber, atTime);
        /// 
        /// //Alle kontrakter også historiske
        /// var isConfirmedGP = flrReadService.ConfirmGP(patientNin,hprNumber, null);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        bool ConfirmGP(string patientNin, int hprNumber, DateTime? atTime);

        /// <summary>
        /// Denne operasjonen er kun tilgjengelig for NAV.
        /// For å hente fastlegeliste med pasienter basert på personnummer til legen og kommune.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// * FlrReadExtended
        /// </remarks>
        /// <param name="doctorNin">Legens personnummer</param>
        /// <param name="municipalityNr">Kommune fastlegelisten gjelder</param>
        /// <param name="doSubstituteSearch">Hvorvidt legen kan være en vikar. Hvis ikke søker vi utelukkende på legen.</param>
        /// <returns>GPContract funnet. På kontrakten vil PatientList være fylt ut.</returns>
        /// <exception cref="ArgumentException">Kastes hvis kommunenr er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis personnummer er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis aktive fastlegelister i gitt kommune er funnet</exception>
        /// <exception cref="ArgumentException">Kastes hvis det mer en en aktiv legeperiode</exception>
        /// <example>
        /// <code>
        /// var contract = flrReadService.GetGPContractForNav(doctorNin,municipalityNr, doSubstituteSearch);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPContract GetGPContractForNav(string doctorNin, string municipalityNr, bool doSubstituteSearch);

        /// <summary>
        /// Returnerer pasientlister på gammelt kith/nav format.
        /// Se <see cref="NavEncryptedPatientListParameters"/> for inputinfo.
        /// Stream som returneres er kryptert ved hjelp av CMS/PKCS#7.
        /// Xml er signert som beskrevet i schema.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrReadExtended
        /// </remarks>
        /// <param name="param">Parametre for uttrekk</param>
        /// <returns>CMS/PKCS#7 cryptert Stream</returns>
        /// <exception cref="ArgumentException">Kastes hvis legens NIN ikke er satt</exception>
        /// <exception cref="ArgumentException">Kastes hvis kommunenummer ikke er satt eller er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis listetype har en ugyldig verdi</exception>
        /// <exception cref="ArgumentException">Kastes hvis angitt måned ikke er satt til den første i måneden</exception>
        /// <exception cref="ArgumentException">Kastes hvis angitt måned er fram i tid</exception>
        /// <exception cref="ArgumentException">Kastes hvis X.509-sertifikat ikke er satt eller er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis receiverXml mangler eller er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis senderXml mangler eller er ugyldig</exception>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Stream NavGetEncryptedPatientList(NavEncryptedPatientListParameters param);

        /// <summary>
        /// Returnerer pasientlister på gammelt kith/nav format.
        /// Se <see cref="NavEncryptedPatientListParameters"/> for beskrivelse av de faktiske parameterene.
        /// Stream som returneres er kryptert ved hjelp av CMS/PKCS#7.
        /// Xml er signert som beskrevet i schema.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene:
        /// * Administrator
        /// * FlrReadExtended
        /// </remarks>
        /// <param name="doctorNIN">Se <see cref="NavEncryptedPatientListParameters.DoctorNIN"/></param>
        /// <param name="municipalityId">Se <see cref="NavEncryptedPatientListParameters.MunicipalityId"/></param>
        /// <param name="encryptWithX509Certificate">Se <see cref="NavEncryptedPatientListParameters.EncryptWithX509Certificate"/></param>
        /// <param name="month">Se <see cref="NavEncryptedPatientListParameters.Month"/></param>
        /// <param name="doSubstituteSearch">Se <see cref="NavEncryptedPatientListParameters.DoSubstituteSearch"/></param>
        /// <param name="senderXml">Se <see cref="NavEncryptedPatientListParameters.SenderXml"/></param>
        /// <param name="receiverXml">Se <see cref="NavEncryptedPatientListParameters.ReceiverXml"/></param>
        /// <param name="listType">Se <see cref="NavEncryptedPatientListParameters.ListType"/></param>
        /// <returns>CMS/PKCS#7 cryptert Stream</returns>    
        /// <exception cref="ArgumentException">Kastes hvis legens NIN ikke er satt</exception>
        /// <exception cref="ArgumentException">Kastes hvis kommunenummer ikke er satt eller er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis listetype har en ugyldig verdi</exception>
        /// <exception cref="ArgumentException">Kastes hvis angitt måned ikke er satt til den første i måneden</exception>
        /// <exception cref="ArgumentException">Kastes hvis angitt måned er fram i tid</exception>
        /// <exception cref="ArgumentException">Kastes hvis X.509-sertifikat ikke er satt eller er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis receiverXml mangler eller er ugyldig</exception>
        /// <exception cref="ArgumentException">Kastes hvis senderXml mangler eller er ugyldig</exception>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Stream NavGetEncryptedPatientListAlternate(string doctorNIN, string municipalityId, byte[] encryptWithX509Certificate, DateTime month, bool doSubstituteSearch, string senderXml, string receiverXml, string listType);

        /// <summary>
        /// Hent ut alle GPContractId's på kontrakter hvis legekontor har et postnummer som er lik eller begynner på postNr.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene:
        /// * Administrator
        /// * FlrRead
        /// </remarks>
        /// <param name="postNr">Postnummer eller starten av postnummer. Dvs. at postNr.Lenght må være 2, 3 eller 4.</param>
        /// <returns>Liste over alle aktive GPContracts.Id hvis legekontor har en besøksadresse (RES/FLO_RES) som begynner med </returns>
        /// <exception cref="ArgumentException">Kastes hvis postnr er feil</exception>
        /// <exception cref="ArgumentException">Kastes hvis postnr ikke er på 2, 3, eller 4 tegn</exception>
        /// <example>
        /// <code>
        /// var contractIdList = flrReadService.GetGPContractIdsOperatingInPostalCode(postnr);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<long> GetGPContractIdsOperatingInPostalCode(string postNr);

        /// <summary>
        /// Søk etter leger.
        /// Dersom du ønsker å søke etter legekontor, bruk HTK tjenesten.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// </remarks>
        /// <param name="searchParameters">Søkeparametere for det tilhørende søk</param>
        /// <returns>Paginert liste med  leger basert på søkeparametetere</returns>
        /// <exception cref="ArgumentException">Kastes hvis feil søkeparameter er oppgitt</exception>
        /// <example>
        /// <code>
        /// //For et gitt tidspunkt
        /// var searchResult = flrReadService.SearchForGP(searchCriteria);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PagedResult<GPDetails> SearchForGP(GPSearchParameters searchParameters);

        /// <summary>
        /// Hent ut kontrakter basert på gitte kriterier.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PagedResult<GPContract> QueryGPContracts(GPContractQueryParameters queryParameters);

        /// <summary>
        /// Henter pasientlister i gammelt NAV fil-format. 
        /// Streamen er ZipArchive.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrReadAllPatients
        /// * AdresseregisterAdministrator må være knyttet til Unit som kontrakten er knyttet til
        /// </remarks>
        /// <param name="parameters" cref="GetNavPatientListsParameters">Bestemmer hva som skal hentes, og i hvilket format</param>
        /// <returns>ZipArchive Stream, der Entries er av typen spesifisert i parameters, se <see cref="GetNavPatientListsParameters.FormatType"/> </returns>
        /// <exception cref="ArgumentException">Kastes hvis format ikke er gyldig</exception>     
        /// <exception cref="ArgumentException">Kastes hvis ingen angitte kontrakts-ider</exception>     
        /// <exception cref="ArgumentException">Kastes hvis bruker ikke har tilgang til å laste ned pasientliste for en eller flere angitte kontrakter</exception>     
        /// <exception cref="ArgumentException">Kastes hvis angitte kontrakter berører flere legekontor</exception>     
        /// <exception cref="ArgumentException">Kastes hvis det ikke fins pasienter på listen for en eller flere angitte kontrakter i oppgitt måned</exception>     
        /// <example>
        /// <code language="cs">
        /// <![CDATA[
        /// var parameters = new GetNavPatientListsParameters
        /// {
        ///     FormatType = "xml",
        ///     Contracts = new[]
        ///     {
        ///         new ContractWithMonth
        ///         {
        ///             ContractId = 31,
        ///             Month = DateTime.Parse("2016-03-01")
        ///         }
        ///     }
        /// };
        ///
        /// using (var archive = new ZipArchive(flrReadService.GetNavPatientLists(parameters)))
        /// {
        ///     foreach (var entry in archive.Entries)
        ///     {
        ///         var enstryStream = entry.Open();
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Stream GetNavPatientLists(GetNavPatientListsParameters parameters);

        /// <summary>
        /// Henter informasjon om et primærhelseteam.
        /// </summary>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * FlrRead
        /// </remarks>
        /// <param name="id">Identifikator for primærhelseteamet som skal returneres</param>
        /// <example>
        /// <code>
        /// flrWriteService.GetPrimaryHealthCareTeam(1234);
        /// </code>
        /// </example>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PrimaryHealthCareTeam GetPrimaryHealthCareTeam(long id);

        /// <summary>
        ///     <para>
        ///         Henter gjesteinnbyggerne i kommunen med kommunenummer lik <paramref name="municipalityCode"/>. Altså: Personer som har <i>fastlegen</i>
        ///         sin i denne kommunen, men er bosatt i en annen kommune.
        ///     </para>
        ///     <para>
        ///     Eksempel: Jens er bosatt i Trondheim, men har sin fastlege i Verdal. Anta at kommunenummeret til Verdal er 5038. Listen som
        ///     returneres ved et kall til GetGuestResidents("5038") vil dermed inneholde Jens.
        ///     </para>
        ///     <para>
        ///         For den "motsatte" operasjonen, se <see cref="GetResidentsThatAreGuestResidentsElsewhere(string)"></see>  
        ///     </para>
        /// </summary>
        /// <param name="municipalityCode">Kode som unikt identifiserer en kommune.</param>
        /// <returns>En CSV-fil med de aktuelle gjesteinnbyggerne. </returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        byte[] GetGuestResidents(string municipalityCode);

        /// <summary>
        ///     <para>
        ///         Henter innbyggerne i kommunen med kommunenummer lik <paramref name="municipalityCode"/> som er gjesteinnbyggere i en <i>annen</i>
        ///         kommune. Altså: Personer som er <i>bosatt</i> i denne kommunen, men har fastlegen sin i en annen kommune.
        ///     </para>
        ///     <para>
        ///         Eksempel: Jens er bosatt i Trondheim, men har sin fastlege i Verdal. Anta at kommunenummeret til Trondheim er 5001. Listen som
        ///         returneres ved et kall til GetResidentsThatAreGuestResidentsElsewhere("5001") vil dermed inneholde Jens.
        ///     </para>
        ///     <para>
        ///         For den "motsatte" operasjonen, se <see cref="GetGuestResidents(string)"></see>  
        ///     </para>
        /// </summary>
        /// <param name="municipalityCode"></param>
        /// <returns>En CSV-fil med de aktuelle innbyggerne.</returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        byte[] GetResidentsThatAreGuestResidentsElsewhere(string municipalityCode);
    }
}
