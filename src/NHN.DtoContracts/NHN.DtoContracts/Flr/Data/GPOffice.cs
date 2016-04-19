using NHN.DtoContracts.Common.en;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Htk;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Beskriver et legekontor.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    [Serializable]
    public class GPOffice : Business
    {
        /// <summary>
        /// Hvorvidt listen er en del av gruppepraksis.
        /// </summary>
        [DataMember]
        public bool IsGroupOffice { get; set; }

        /// <summary>
        /// Bydel. Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/bydel">bydel</see> (OID 3403).
        /// </summary>
        [DataMember]
        public Code District { get; set; }
    }
}