using System;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Logging.Data
{
    /// <summary>
    /// Søkeparametre for å hente ut logging av forspørsler sendt til registerplatformen
    /// For øyeblikket er det bare FlrReadOperationService og FlrExportOperationService som registrerer logging av forspørsler sendt ifm henting av faslegelister.
    /// </summary>
    [DataContract(Namespace = Logging.LogFetchingNamespace.Name)]
    [Serializable]
    public class RequestTrackedLogQueryParameters
    {
        /// <summary>
        /// Brukernavn til bruker som en ønsker å hente ut loggede forespørsler for. 
        /// </summary>
        [DataMember]
        public string RequestedBy { get; set; }

        /// <summary>
        /// Tidsperiode for når forespøslene ble gjort. 
        /// </summary>
        [DataMember]
        public Period RequestedPeriod { get; set; }

        /// <summary>
        /// Grenesnittet til tjenesten som ble benyttet til å sende en forespørseler. F.eks FlrReadOperationServices
        /// </summary>
        [DataMember]
        public string ServiceName { get; set; }

        /// <summary>
        /// Metode navnet forespørselen ble sendt til. F.eks GetGPPatientList.
        /// </summary>
        [DataMember]
        public string MethodName { get; set; }

        /// <summary>
        /// Antall elementer i svaret (antall per side)
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }

        /// <summary>
        /// Sidenummer som skal hentes (eks: 500 resultater, 50 per side, side 2 returnerer resultat 50-100)
        /// </summary>
        [DataMember]
        public int Page { get; set; }

    }
}
