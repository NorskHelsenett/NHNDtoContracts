﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Logging.Data
{
    /// <summary>
    /// Log av forspørsel sendt til registerplatformen
    /// </summary>
    [DataContract(Namespace = LogFetchingNamespace.Name)]
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
        /// Hvor lang tid forespørselen tok å prosessere i sekunder
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

        /// <summary>
        /// Viser om forespørselen har feilet.
        /// </summary>
        [DataMember]
        public bool Faulted { get; set; }

        /// <summary>
        /// Ekstra data som er tatt ut fra Parametere for å lettere hente frem relevent data. 
        /// </summary>
        [DataMember]
        public IList<RequestTrackedLogParameter> RequestTrackedLogParameters { get; set; }
    }
}
