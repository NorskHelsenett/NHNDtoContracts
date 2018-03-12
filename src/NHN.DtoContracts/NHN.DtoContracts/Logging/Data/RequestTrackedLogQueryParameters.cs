using System;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Logging.Data
{
    /// <summary>
    /// Søkeparametre for å hente ut logging av forspørsler sendt til registerplatformen
    /// For øyeblikket er det bare FlrReadOperationService og FlrExportOperationService som registrerer logging av forspørsler sendt ifm henting av faslegelister.
    /// </summary>
    [DataContract(Namespace = LogFetchingNamespace.Name)]
    [Serializable]
    public class RequestTrackedLogQueryParameters
    {
        /// <summary>
        /// Brukernavn til bruker som en ønsker å hente ut loggede forespørsler for. Vil retunerer alle brukere dersom bruker ikke er spesifisert.
        /// </summary>
        [DataMember]
        public string RequestedBy { get; set; }

        /// <summary>
        /// Tidsperiode for når forespøslene ble gjort. Påkrevd.
        /// </summary>
        [DataMember]
        public Period RequestedPeriod { get; set; }

        /// <summary>
        /// Grenesnittet til tjenesten som ble benyttet til å sende en forespørseler. F.eks FlrReadOperationServices
        /// Vil returnerer forespørseler på tvers av registrer i registerplatformen dersom grenesnittet ikke er spesifisert. Kan inneholde starten av grenesnittet navnet.
        /// For kall mot metoder spesifisert for fastlegeregistret er det påkrevd å ha minst "Flr" som søkeord i grensesnitt navnet.
        /// </summary>
        [DataMember]
        public string ServiceName { get; set; }

        /// <summary>
        /// Metode navnet forespørselen ble sendt til. F.eks GetGPPatientList.
        /// Vil retunere forespørseler på tvers av metoder dersom metodenavnet ikke er spesifiksert. Kan inneholder starten av metodenavnet.
        /// </summary>
        [DataMember]
        public string MethodName { get; set; }

        /// <summary>
        /// Antall elementer i svaret (antall per side)
        /// Vil retunere default 200 resulter pr side, dersom antallet ikke er spesifisert.
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }

        /// <summary>
        /// Sidenummer som skal hentes (eks: 500 resultater, 50 per side, side 2 returnerer resultat 50-100)
        /// Vil retunere default sidenummer 1, dersom sidenummer ikke er spesifisert.
        /// </summary>
        [DataMember]
        public int Page { get; set; }
    }
}
