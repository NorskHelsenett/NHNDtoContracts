using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;
using System.Linq;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Parametere for export
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class ContractsQueryParameters   
    {
        /// <summary>
        /// Kun pasientlister som tilhører i disse kommunene blir returnert.
        /// Er denne listen tom, returneres alle pasientlister.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/kommune">kommune</see> (OID 3402).
        /// </summary>
        [DataMember]
        public IList<Code> Municipalities { get; set; }

        /// <summary>
        /// Om man absolutt må hente personinfo fra personregisteret, settes denne til true.
        /// Oppslag i personregisteret vil gjøre at svar vil ta VESENTLIG lengre tid
        /// </summary>
        [DataMember]
        public bool GetFullPersonInfo { get; set; }

        /// <summary>
        /// Er denne false, vil kun <see cref="GPContract"/>s som var aktive på eksporttidspunktet bli returnert. 
        /// <see cref="GPContract.PatientList"/> vil da også kun inneholde pasienter som var aktive på listen på eksporttidspunktet.
        /// 
        /// Er denne true, vil alle <see cref="GPContract"/>s, inkludert de som er kansellert/utgått/etc bli returnert.
        /// <see cref="GPContract.PatientList"/> vil da også inneholde full pasienthistorikk.
        /// </summary>
        [DataMember]
        public bool GetHistoricalData { get; set; }

        /// <summary>
        /// Primært for å hente innholdet i objektet ved logging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"FullPersonInfo: {GetFullPersonInfo}, HistoricalData: {GetHistoricalData}, Municipalities: {string.Join(", ", Municipalities.Select(c => c.CodeValue + " " + c.CodeText))}";
        }
    }
}
