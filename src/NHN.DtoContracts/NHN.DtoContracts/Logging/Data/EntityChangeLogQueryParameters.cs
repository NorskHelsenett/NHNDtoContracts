using System;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Logging.Data
{
    [DataContract(Namespace = Namespaces.LogFetchingV1)]
    [Serializable]
    public class EntityChangeLogQueryParameters
    {
        /// <summary>
        /// Hvilken metode som ble kalt for endringen.
        /// </summary>
        [DataMember]
        public string Method { get; set; }

        /// <summary>
        /// Tidsperiode for når forespøslene ble gjort. Påkrevd.
        /// </summary>
        [DataMember]
        public Period ChangedPeriod { get; set; }

        /// <summary>
        /// Bruker som har utført endringen
        /// </summary>
        [DataMember]
        public string RequestedBy { get; set; }

        /// <summary>
        /// HerId til enheten som ble endret på.
        /// </summary>
        [DataMember]
        public int? HerId { get; set; }

        /// <summary>
        /// Organisasjonsnummer til enheten som ble endret på
        /// </summary>
        [DataMember]
        public int? OrgNr { get; set; }

        /// <summary>
        /// ReshId til enheten som ble endret på
        /// </summary>
        [DataMember]
        public int? ReshId { get; set; }

        /// <summary>
        /// Størrelsen på sidene i det returnerte paginerte resultatet.
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }

        /// <summary>
        /// Siden for ønsket resultat i det paginerte resultatet.
        /// </summary>
        [DataMember]
        public int Page { get; set; }
    }
}
