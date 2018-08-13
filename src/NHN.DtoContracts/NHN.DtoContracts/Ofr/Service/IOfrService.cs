using System;
using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.Ofr.Data;

namespace NHN.DtoContracts.Ofr.Service
{
    /// <summary>
    /// Tjeneste for å hente ut og legge til informasjon i Oppføringsregisteret (OFR)
    /// </summary>
    [ServiceContract(Namespace = Namespaces.OfrV1,
        Name = "IOfrService")]
    public interface IOfrService
    {
        /// <summary>
        /// Legger til en ny oppføring om et helseregister i Oppføringsregisteret.
        /// </summary>
        /// <param name="healthRegister">Objekt som inneholder opplysninger om en oppførin. </param>
        /// <returns>Objekt med den nye oppføringen som er blitt lagt til i registeret.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var healthRegister = ofrService.AddHealthRegister(healthRegister);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        HealthRegister AddHealthRegister(HealthRegister healthRegister);

        /// <summary>
        /// Henter en helseregisteroppføring fra registeret.
        /// </summary>
        /// <param name="healthRegisterId">Unik identifikator for helseregisteroppføringen</param>
        /// <returns>Objekt med oppføringen med spesifisert id fra registeret.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var healthRegister = ofrService.GetHealhRegister(healthRegisterId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        HealthRegister GetHealthRegister(Guid healthRegisterId);

        ///// <summary>
        ///// Henter en liste med helseregisteroppføringer fra OFR registeret basert på registerid'er
        ///// </summary>
        ///// <param name="registerIds">Liste med unik identifikator (string) for helseregisteroppføringen. Alternativ unik identifikator for guid</param>
        ///// <returns>Liste med helseregisteroppføringer basert på registerid'er</returns>
        ///// <exception cref="ArgumentException"></exception>
        ///// <example>
        ///// <code>
        /////     var healthRegisters = _ofrServiceImplementation.GetHealthRegisters(registerIds);
        ///// </code>
        ///// </example>
        ///// <remarks>
        ///// ##### Krever en av rollene
        ///// * Administrator
        ///// * OfrAdministrator
        ///// * OfrSuperUser for gjeldende register
        ///// * OfrUser for gjeldende register
        ///// * OfrApiUser for gjeldende register
        ///// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<HealthRegister> GetHealthRegisters(ICollection<string> registerIds);

        /// <summary>
        /// Oppdaterer gitt helseregisteroppføring med ny oppgitt informasjon.
        /// </summary>
        /// <param name="healthRegister">Objekt som beskriver den oppdaterte informasjonen for et helseregister.</param>
        /// <returns>Objektet for den oppdaterte helseregisteroppføringen.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var healthRegister = ofrService.UpdateHealthRegister(healthRegister);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        HealthRegister UpdateHealthRegister(HealthRegister healthRegister);

        /// <summary>
        /// Sletter en helseregisteroppføring fra registeret.
        /// </summary>
        /// <param name="healthRegisterId">Id til helseregisteroppføringen man ønsker å slette.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// ofrService.DeleteHealthRegister(healthRegisterId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void DeleteHealthRegister(Guid healthRegisterId);

        /// <summary>
        /// Henter alle helseregisteroppføringer personen for gitt nin er knyttet til. Kan også ta inn argument for å filtrer på type.
        /// </summary>
        /// <param name="nin">Personnummer for person man skal ha informasjon om.</param>
        /// <param name="healthRegisterType">Type helseregistre man vil ha i retur, representert av en kode i et kodeverk</param>
        /// <returns>Liste over helseregisterobjekter.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var type = new Code{ CodeValue = "ofr_forskningsprosjekt", SimpleType = "ofr_helseregistertype" }; 
        /// var healthRegisters = ofrService.GetHealthRegistersForPerson(nin, type);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<HealthRegister> GetHealthRegistersFor(string nin, Code healthRegisterType = null);

        /// <summary>
        /// Utfører et søk på helseregisteroppføringer med gitte parametre.
        /// </summary>
        /// <param name="query">Objekt som beskriver et sett med parametre for å utføre søk.</param>
        /// <returns>Resultat med helseregisteroppføringer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var query = new HealthRegisterQuery
        /// {
        ///     BelongsToOrg = 12345678,
        ///     FullText = "HUNT",
        ///     Type = new ws.Code {CodeValue = "ofr_forskningsprosjekt", SimpleType = "ofr_helseregistertype"},
        ///     WasActiveAtTime = DateTime.ParseExact("02.02.2016", "dd.MM.yyyy", CultureInfo.InvariantCulture)
        /// };
        /// var healtRegisters = ofrService.QueryHealthRegisters(query);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<HealthRegister> QueryHealthRegisters(HealthRegisterQuery query);

        /// <summary>
        /// Henter ut alle personer som er assosiert med gitt helseregister, returnerer som paginert resultat.
        /// </summary>
        /// <param name="page">Id for helseregisteroppføring man ønsker informasjon om.</param>
        /// <param name="pageSize">Id for helseregisteroppføring man ønsker informasjon om.</param>
        /// <param name="healthRegisterId">Id for helseregisteroppføring man ønsker informasjon om.</param>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var page = 1;
        /// var pageSize = 10;
        /// var personAssociationsPaginatedResult = ofrService.PeopleOnHealthRegister(page, pageSize, healthRegisterId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociations PeopleOnHealthRegister(int page, int pageSize, Guid healthRegisterId);

        /// <summary>
        /// Legger til personer i en oppføring i Oppføringsregisteret.
        /// </summary>
        /// <param name="healthRegisterId">Id til helseregister</param>
        /// <param name="people">Liste over personer som skal legges til</param>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code language="cs">
        /// <![CDATA[
        /// var people = new List<AddPersonData>
        /// {
        ///     new AddPersonData { Nin = "12345678901", StartPeriod = DateTime.Now },
        ///     new AddPersonData { Nin = "12345679231", StartPerido = DateTime.Now }
        /// }
        /// var personAssociations = ofrService.AddPeople(healthregisterId, people);
        /// ]]>
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociations AddPeople(Guid healthRegisterId, ICollection<AddPersonData> people);


        /// <summary>
        /// Simulerer å leegge til personer i en oppføring i Oppføringsregisteret. Lagrer ikke dataen i db, men returnerer resultatet som ville blitt lagt til. 
        /// Returnerer i tillegg err
        /// </summary>
        /// <param name="healthRegisterId">Guid til helseregister</param>
        /// <param name="people">Liste over personer som skal legges til</param>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// var people = new List<AddPersonData>
        /// {
        ///     new AddPersonData { Nin = "12345678901", StartPeriod = DateTime.Now },
        ///     new AddPersonData { Nin = "12345679231", StartPerido = DateTime.Now }
        /// }
        /// var personAssociationsWithErrors = ofrService.AddPeople(healthregisterId, people);
        /// ]]>
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociationsWithErrors AddPeopleDryRun(Guid healthRegisterId, ICollection<AddPersonData> people);

        /// <summary>
        /// Legger til personer i en oppføring i Oppføringsregisteret. Tar inn personer representert som csv string.
        /// Csv string input kan være av typen "[nin];[StartDate];[ExternalRef];" per linje, hvor StartDate og ExternalRef er valgfritt. 
        /// Startdato input takles kun på format "yyyy-MM-dd HH:mm:ss".
        /// </summary>
        /// <param name="csv">Csv string som representerer personer som skal legges til.</param>
        /// <param name="healthRegisterId">Guid for helseregisteroppføringen hvor personene skal legges til.</param>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// //Tar inn csv-formatert string
        /// var people = "12345678910; 2016-02-02 12:12:12; referanse; \\n123857264721; 2016-02-02 12:12:12; referanse;\\n"
        /// var personAssociationsWithErrors = ofrService.AddPeople(healthregisterId, people);
        /// ]]>
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociations AddPeopleFromCsv(string csv, Guid healthRegisterId);

        /// <summary>
        /// Legger til personer i en oppføring i Oppføringsregisteret. Tar inn personer representert som csv string.
        /// Csv string input kan være av typen "[nin];[StartDate];[ExternalRef];" per linje, hvor StartDate og ExternalRef er valgfritt. 
        /// Startdato input takles kun på format "yyyy-MM-dd HH:mm:ss".
        /// </summary>
        /// <param name="csv">Csv string som representerer personer som skal legges til.</param>
        /// <param name="healthRegisterId">Guid for helseregisteroppføringen hvor personene skal legges til.</param>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// //Tar inn csv-formatert string
        /// var people = "12345678910; 2016-02-02 12:12:12; referanse; \\n123857264721; 2016-02-02 12:12:12; referanse;\\n"
        /// var personAssociationsWithErrors = ofrService.AddPeople(healthregisterId, people);
        /// ]]>
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociationsWithErrors AddPeopleFromCsvDryRun(string csv, Guid healthRegisterId);

        /// <summary>
        /// Fjerner gitte personer fra en helseregisteroppføring, i praksis invalideres her personene og vil fortsatt kunne vises historisk.
        /// </summary>
        /// <param name="nins">En liste med personnummer for personer man ønsker å fjerne.</param>
        /// <param name="healthRegisterId">Id for helseregisteroppføring man ønsker å fjerne personer fra.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// ofrService.RemovePeople(nins, healthRegisterId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void RemovePeople(ICollection<string> nins, Guid healthRegisterId);

        /// <summary>
        /// Fjerner gitte personer fra helseregisteroppføring og historisk.
        /// </summary>
        /// <param name="nins">En liste med personnummer for personer man ønsker å fjerne.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// ofrService.RemovePeopleFromHistory(nins);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// * Administrator
        /// * OfrAdministrator
        /// * OfrSuperUser for gjeldende register
        /// * OfrUser for gjeldende register
        /// * OfrApiUser for gjeldende register
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void RemovePeopleFromHistory(ICollection<string> nins);

        /// <summary>
        /// Sjekk om du er register eier for en helseregisteroppføring.
        /// </summary>
        /// <param name="healthRegisterId">Guid for helseregisteroppføringen hvor du ønsker å sjekke om brukeren din er eier av.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// ofrService.IsOwnerOfHealthRegister(healthRegisterId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// Krever ingen roller.
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        bool IsOwnerOfHealthRegister(Guid healthRegisterId);

        /// <summary>
        /// Henter ut en person med gitt fødseslsnummer oppført på helseregister med gitt guid.
        /// </summary>
        /// <param name="nin">Fødselsnummeret til personene.</param>
        /// <param name="healthRegisterId">Guid for helseregisteroppføringen hvor personen er oppført.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// ofrService.GetParticipant(nin, healthRegisterId);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// Krever ingen roller.
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonOnHealthRegister GetParticipant(string nin, Guid healthRegisterId);

        /// <summary>
        /// Henter ut en navn på person med gitt fødseslsnummer.
        /// </summary>
        /// <param name="nin">Fødselsnummeret til personene.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// ofrService.GetParticipantName(nin);
        /// </code>
        /// </example>
        /// <remarks>
        /// ##### Krever en av rollene
        /// Krever at deltager hører til en av registerene du har lov til å se.
        /// Vil ikke returnere navnet på deltagere som er i registre du ikke har tilgang til.
        /// </remarks>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonName GetParticipantName(string nin);
    }
}
