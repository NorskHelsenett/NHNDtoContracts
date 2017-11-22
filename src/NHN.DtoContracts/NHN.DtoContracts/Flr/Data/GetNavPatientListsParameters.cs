using System.Collections.Generic;
using System.Linq;
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
        /// disk = Nav-Filformat med konstant lengde
        /// xml = Navn-Xml format
        /// </summary>
        [DataMember]
        public string FormatType { get; set; }

        /// <summary>
        /// Primært for å hente innholdet i objektet ved logging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"FormatType: {FormatType}; Contracts[ {string.Join(", ", Contracts.Select(c => "ContractId:" + c.ContractId.ToString() + "; Month:" + c.Month.ToString()))}]";
        }
    }
}
