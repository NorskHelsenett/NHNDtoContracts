using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Parametere for export
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class ContractsQueryParameters   
    {
        /// <summary>
        /// Kun pasientlister som tilh�rer i disse kommunene blir returnert
        /// Er denne listen tom, returneres alle pasientlister
        /// </summary>
        [DataMember]
        public ICollection<Code> Municipalities { get; set; }

        /// <summary>
        /// Om man absolutt m� hente personinfo fra personregisteret, settes denne til true.
        /// Oppslag i personregisteret vil gj�re at svar vil ta VESENTLIG lengre tid
        /// </summary>
        [DataMember]
        public bool GetFullPersonInfo { get; set; }
        /// <summary>
        /// Om man skal benytte svaret til statistic.
        /// Gj�r at brukere uten extendedRead rettigheter kan benytte exporten
        /// </summary>
        public bool StatisticsQuery { get; set; }
    }
}