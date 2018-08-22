using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.ServiceBus.Data;

namespace NHN.DtoContracts.ServiceBus.Service
{

    /// <summary>
    /// MERK: Dette grensesnittet er i alfa-tilstand og ikke-bakoverkompatible endringer kan skje.
    /// </summary>
    [ServiceContract(Namespace = Namespaces.ServiceBusManagerV1,
        Name = "IServiceBusManager")]
    public interface IServiceBusManager
    {
        /// <summary>
        /// Legger til en ny subscription for brukeren som gjør operasjonen, eller henter et eksisterende dersom et abonnement allerde eksisterer.
        /// </summary>
        /// <param name="eventSource">Navn på kilde til events. En av "flr", "addresseregister", "hpr", "htk".</param>
        /// <param name="userSystemIdent">Navn på systemidentifikator for systemet som ønsker abonnementet. Dette er helt brukerspesifikt, men er påkrevd. Bruk bare "Ingen" som konstant parameter dersom det ikke er behov ut ut over ett abonnement på en kø.</param>
        /// <returns>Informasjon om abonnement</returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        SubscriptionInfo AddOrGetSubscription(string eventSource, string userSystemIdent);

        /// <summary>
        /// Henter informasjon om topic abonnementer på et gitt register.
        /// </summary>
        /// <param name="eventSource">Navn på kilde til events. </param>
        /// <returns>informasjon om abonnement. Merk at hvis ikke noe abonnement finnes, så returneres null.</returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        IList<SubscriptionInfo> GetSubscriptions(string eventSource);

        /// <summary>
        /// Sletter et eksisterende abonnement. Må brukes dersom rettighetene til nåværende bruker har endret seg og man ønsker at dette skal reflekteres i rettigheten på abonnementet.
        /// </summary>
        /// <param name="subscriptionInfo"></param>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void DeleteSubscription(SubscriptionInfo subscriptionInfo);
    }
}
