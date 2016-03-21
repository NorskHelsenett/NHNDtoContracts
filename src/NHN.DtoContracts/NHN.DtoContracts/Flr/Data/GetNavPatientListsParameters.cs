using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Bestemmer hva som skal hentes og i hvilken form
    /// </summary>
    [DataContract]
    public class GetNavPatientListsParameters
    {
        /// <summary>
        /// Kontraktene man vil hente pasientlister til, for en bestemt måned
        /// </summary>
        [DataMember]
        public IEnumerable<ContractWithMonth> Contracts { get; set; }

        /// <summary>
        /// Formatet som blir returnert, kan være txt eller xml.
        /// txt = Nav-Filformat med konstant lengde
        /// xml = Navn-Xml format
        /// </summary>
        [DataMember]
        public string FormatType { get; set; }
    }
}