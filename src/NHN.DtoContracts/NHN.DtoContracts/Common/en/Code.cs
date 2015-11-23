using NHN.DtoContracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// En kode hentet fra et kodeverk.
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglishOld)]
    [Serializable]
    public class Code
    {
        /// <summary>
        /// Tomt Code objekt, Active = true
        /// </summary>
        public Code()
        {
            Active = true;
        }

        [OnDeserializing]
        private void SetDefaultStates(StreamingContext c)
        {
            Active = true;
        }

        /// <summary>
        /// Opprett Code.
        /// </summary>
        public Code(string simpleType, int oid=0, string value=null)
        {
            if (string.IsNullOrWhiteSpace(simpleType))
                throw new ArgumentNullException("simpleType");
            SimpleType = simpleType;
            if (oid > 0)
                OID = oid;
            if (value != null)
                CodeValue = value;
            Active = true;
        }

        /// <summary>
        /// OID som brukes for denne koden.
        /// </summary>
        [DataMember]
        public int OID { get; set; }

        /// <summary>
        /// Navn på OID/type.
        /// </summary>
        [DataMember]
        public string SimpleType { get; set; }

        /// <summary>
        /// Verdien for koden, hentet fra OID.
        /// </summary>
        [DataMember]
        public string CodeValue { get; set; }

        /// <summary>
        /// Beskrivelse av kodeverdien.
        /// </summary>
        [DataMember]
        public string CodeText { get; set; }

        /// <summary>
        /// Hvorvidt koden er aktiv eller ikke. En inaktiv kode skal ikke brukes på nye objekter.
        /// </summary>
        [DataMember]
        public bool Active { get; set; }
    }
}
