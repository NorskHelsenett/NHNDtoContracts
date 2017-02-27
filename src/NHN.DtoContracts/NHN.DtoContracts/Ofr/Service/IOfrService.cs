using System;
using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.Ofr.Data;

namespace NHN.DtoContracts.Ofr.Service
{
    /// <summary>
    /// X
    /// </summary>
    [ServiceContract(Namespace = OfrNamespace.Name)]
    public interface IOfrService
    {
        /// <summary>
        /// Legger til en ny oppføring om et helseregister i Oppføringsregisteret.
        /// </summary>
        /// <param name="healthRegister">Objekt som inneholder opplysninger om en oppførin. </param>
        /// <value></value>
        /// <returns>Objekt med den nye oppføringen som er blitt lagt til i registeret.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var healthRegister = oprService.AddHealthRegister(healthRegister);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        HealthRegister AddHealthRegister(HealthRegister healthRegister);

        /// <summary>
        /// Henter en helseregisteroppføring fra registeret.
        /// </summary>
        /// <param name="healthRegisterId">Unik identifikator for helseregisteroppføringen</param>
        /// <value></value>
        /// <returns>Objekt med oppføringen med spesifisert id fra registeret.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var healthRegister = oprService.GetHealhRegister(healthRegisterId);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        HealthRegister GetHealthRegister(Guid healthRegisterId);

        /// <summary>
        /// Oppdaterer gitt helseregisteroppføring med ny oppgitt informasjon.
        /// </summary>
        /// <param name="healthRegister">Objekt som beskriver den oppdaterte informasjonen for et helseregister.</param>
        /// <value></value>
        /// <returns>Objektet for den oppdaterte helseregisteroppføringen.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var healthRegister = oprService.UpdateHealthRegister(healthRegister);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        HealthRegister UpdateHealthRegister(HealthRegister healthRegister);

        /// <summary>
        /// Sletter en helseregisteroppføring fra registeret.
        /// </summary>
        /// <param name="healthRegisterId">Id til helseregisteroppføringen man ønsker å slette.</param>
        /// <value></value>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// oprService.DeleteHealthRegister(healthRegisterId);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void DeleteHealthRegister(Guid healthRegisterId);

        /// <summary>
        /// Henter alle helseregisteroppføringer personen for gitt nin er knyttet til.
        /// </summary>
        /// <param name="nin">Personnummer for person man skal ha informasjon om.</param>
        /// <param name="healthRegisterType">Type helseregistre man vil ha i retur</param>
        /// <value></value>
        /// <returns>Liste over helseregisterobjekter.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var healthRegisters = oprService.GetHealthRegistersForPerson(nin);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<HealthRegister> GetHealthRegistersFor(string nin, Code healthRegisterType = null);

        /// <summary>
        /// Utfører et søk på helseregisteroppføringer med gitte parametre.
        /// </summary>
        /// <param name="query">Objekt som beskriver et sett med parametre for å utføre søk.</param>
        /// <value></value>
        /// <returns>Et paginert resultat med helseregisteroppføringer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var healRegistersPaginatedResult = oprService.QueryHealthRegisters(query);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<HealthRegister> QueryHealthRegisters(HealthRegisterQuery query);

        /// <summary>
        /// Henter ut alle personer som er assosiert med gitt helseregister.
        /// </summary>
        /// <param name="page">Id for helseregisteroppføring man ønsker informasjon om.</param>
        /// <param name="pageSize">Id for helseregisteroppføring man ønsker informasjon om.</param>
        /// <param name="healthRegisterId">Id for helseregisteroppføring man ønsker informasjon om.</param>
        /// <value></value>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var personAssociations = oprService.PeopleOnHealthRegister(healthRegisterId);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociations PeopleOnHealthRegister(int page, int pageSize, Guid healthRegisterId);

        /// <summary>
        /// Legger til personer i en oppføring i Oppføringsregisteret.
        /// </summary>
        /// <param name="healthRegisterId">Id til helseregister</param>
        /// <param name="people">Liste over personer som skal legges til</param>
        /// <value></value>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var person = new AddPersonData { Nin = "12345678901", StartPeriod = DateTime.Now };
        /// var personAssociations = oprService.AddPeople(new [] { person }, false);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociations AddPeople(Guid healthRegisterId, ICollection<AddPersonData> people);


        /// <summary>
        /// Simulerer å leegge til personer i en oppføring i Oppføringsregisteret. Lagrer ikke dataen i db, men returnerer resultatet som ville blitt lagt til. 
        /// Returnerer i tillegg err
        /// </summary>
        /// <param name="healthRegisterId">Guid til helseregister</param>
        /// <param name="people">Liste over personer som skal legges til</param>
        /// <value></value>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var person = new AddPersonData { Nin = "12345678901", StartPeriod = DateTime.Now };
        /// var personAssociations = oprService.AddPeople(new [] { person }, false);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociationsWithErrors AddPeopleDryRun(Guid healthRegisterId, ICollection<AddPersonData> people);

        /// <summary>
        /// Legger til personer i en oppføring i Oppføringsregisteret.
        /// </summary>
        /// <param name="csv">Csv string som representerer personer som skal legges til.</param>
        /// <param name="healthRegisterId">Guid for helseregisteroppføringen hvor personene skal legges til.</param>
        /// <value></value>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var personAssociations = oprService.AddPeople(nins, healthRegister, justViewResults)
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociations AddPeopleFromCsv(string csv, Guid healthRegisterId);

        /// <summary>
        /// Legger til personer i en oppføring i Oppføringsregisteret.
        /// </summary>
        /// <param name="csv">Csv string som representerer personer som skal legges til.</param>
        /// <param name="healthRegisterId">Guid for helseregisteroppføringen hvor personene skal legges til.</param>
        /// <value></value>
        /// <returns>Objekt som beskriver assosiasjonen mellom en oppføring og personer.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// var personAssociations = oprService.AddPeople(nins, healthRegister, justViewResults)
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        PersonAssociationsWithErrors AddPeopleFromCsvDryRun(string csv, Guid healthRegisterId);

        /// <summary>
        /// Fjerner gitte personer fra en helseregisteroppføring.
        /// </summary>
        /// <param nins="">En liste med personnummer for personer man ønsker å fjerne.</param>
        /// <param healthRegisterId="">Id for helseregisteroppføring man ønsker å fjerne personer fra.</param>
        /// <value></value>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// oprService.RemovePeople(nins, healthRegisterId);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void RemovePeople(ICollection<string> nins, Guid healthRegisterId);

        /// <summary>
        /// Fjerner gitte personer fra helseregisteroppføring og historisk.
        /// </summary>
        /// <param nins="">En liste med personnummer for personer man ønsker å fjerne.</param>
        /// <value></value>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        /// <code>
        /// oprService.RemovePeopleFromHistory(nins);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller REGISTER_EIER for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void RemovePeopleFromHistory(ICollection<string> nins);
    }
}
