using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.Logging.Service;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Logging.Data
{
    /// <summary>
    /// Ekstra data som er trukket ut av RequestTrackedLog.Parameter for å gjøre det lettere å finne relevant forespørsel
    /// </summary>
    public class RequestTrackedLogParameter
    {
        /// <summary>
        /// Type data som er hentet ut. Pr nå er det bare FLR relaterte parametrer som eksplisit hentes ut F.eks ContractId og MunicipalityId
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// Verdien som er hentet ut. Dette f.eks representere en FLR kontakt Id.
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Ekstra verdi til parameteret. Dette kan f.eks være et tidspunkt definert i sammenheng med en verdi. F.eks GetNavPatientListsParameters 
        /// der vi har liste med kontrakter som inneholder kontrakts id og måneden for uttrekk for den gitte kontrakten. (Type ="ContractIdMonthPair", Value ="123", ValueDetail="2017-11")
        /// </summary>
        [DataMember]
        public string ValueDetail { get; set; }
    }
}
