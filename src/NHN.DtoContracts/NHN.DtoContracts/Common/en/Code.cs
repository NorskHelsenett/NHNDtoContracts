using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// En kode hentet fra et kodeverk.
    /// </summary>
    [DataContract(Namespace = Namespaces.CommonOldV1)]
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
                throw new ArgumentNullException(nameof(simpleType));
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

        /// <summary>
        /// Tekstlig kompakt representasjon.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return $"Code[{SimpleType}({OID}):{CodeValue}{(Active?"":":Inactive")}]";
        }

        /// <summary>
        /// Equality comparison
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator ==(Code c1, Code c2)
        {
            if (object.ReferenceEquals(c1, c2))
                return true;
            if (object.ReferenceEquals(c1, null) || object.ReferenceEquals(c2, null))
                return false;
            return c1.Equals(c2);
        }

        /// <summary>
        /// Inequality
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator !=(Code c1, Code c2)
        {
            if (object.ReferenceEquals(c1, c2))
                return false;
            if (object.ReferenceEquals(c1, null) || object.ReferenceEquals(c2, null))
                return true;
            return !c1.Equals(c2);
        }

        /// <summary>
        /// Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var code = obj as Code;
            if (object.ReferenceEquals(this, code))
                return true;
            if (object.ReferenceEquals(code, null))
                return false;
            return (code.CodeValue == CodeValue && (CodeValue != null || CodeText == code.CodeText)) &&
                   ((code.OID > 0 && code.OID == OID) || code.SimpleType == SimpleType) && code.Active == Active;
        }

        /// <summary>
        /// GetHashCode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (OID != 0 && CodeValue != null)
                return OID.GetHashCode() | CodeValue.GetHashCode();
            if (OID != 0)
                return OID.GetHashCode();
            return SimpleType != null ? SimpleType.GetHashCode() : base.GetHashCode();
        }
    }
}
