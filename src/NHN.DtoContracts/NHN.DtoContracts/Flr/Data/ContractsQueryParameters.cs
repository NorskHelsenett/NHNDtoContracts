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
        /// Kun pasientlister som tilhører i disse kommunene blir returnert
        /// Er denne listen tom, returneres alle pasientlister
        /// </summary>
        [DataMember]
        public ICollection<Code> Municipalities { get; set; }

        /// <summary>
        /// Om man absolutt må hente personinfo fra personregisteret, settes denne til true.
        /// Oppslag i personregisteret vil gjøre at svar vil ta VESENTLIG lengre tid
        /// </summary>
        [DataMember]
        public bool GetFullPersonInfo { get; set; }

        /// <summary>
        /// Sett til true om man vil ha alle historiske data, 
        /// dvs alle leger og pasienter som har vært knyttet til en GPContract med perioden
        /// </summary>
        [DataMember]
        public bool GetHistoricalData { get; set; }
    }
}