using NHN.DtoContracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHN.DtoContracts.Logging.Data
{
    /// <summary>
    /// Log av forspørsel sendt til registerplatformen
    /// </summary>
    [DataContract(Namespace = Logging.LogFetchingNamespace.Name)]
    [Serializable]
    public class RequestTrackedLog
    {
        /// <summary>
        /// Brukernavn til bruker som har sendt forespørselen
        /// </summary>
        [DataMember]
        public string RequestedBy { get; set; }

        /// <summary>
        /// Når forespørselen ble mottat
        /// </summary>
        [DataMember]
        public DateTime RequestedOn { get; set; }

        /// <summary>
        /// Hvor lang tid forespørselen tok å prosessere
        /// </summary>
        [DataMember]
        public double Duration { get; set; }

        /// <summary>
        /// Namespace forespølselen ble sendt til
        /// </summary>
        [DataMember]
        public string ServiceName { get; set; }

        /// <summary>
        /// Metoden forespørselen ble sendt til
        /// </summary>
        [DataMember]
        public string MethodName { get; set; }

        /// <summary>
        /// Parametere som ble sendt i forespørselen.
        /// </summary>
        [DataMember]
        public string RequestParameters { get; set; }

    }
}
