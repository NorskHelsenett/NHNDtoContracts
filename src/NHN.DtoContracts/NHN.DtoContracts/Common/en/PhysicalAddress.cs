using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Fysisk adresse, f.eks. besøks-, post- eller fakturaadresse.
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglishOld)]
    [Serializable]
    public class PhysicalAddress
    {
        /// <summary>
        /// Note: Reference to Type will not be cloned.
        /// </summary>
        public PhysicalAddress Clone()
        {
            return (PhysicalAddress)MemberwiseClone();
        }

        /// <summary>
        /// Dato og tid for siste endring til objektet
        /// </summary>
        [DataMember]
        public DateTime LastChanged { get; set; }

        private Code _type;
        /// <summary>
        /// Type adresse. (RES/PST/ osv)
        /// </summary>
        [DataMember]
        public Code Type
        {
            get { return _type; }

            set
            {
                if (value != null)
                {
                    if (value.OID != 0 && value.OID != 3401)
                        throw new InvalidOperationException("PhysicalAddress can only have OID value 3401");
                    if (!string.IsNullOrEmpty(value.SimpleType) && value.SimpleType != "adressetype")
                        throw new InvalidOperationException("PhysicalAddress can only have code group 'adressetype'");
                }

                _type = value;
            }
        }

        /// <summary>
        /// Postboks
        /// </summary>
        [DataMember]
        public string Postbox { get; set; }

        /// <summary>
        /// Gateadresse
        /// </summary>
        [DataMember]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Postkode
        /// </summary>
        [DataMember]
        public int PostalCode { get; set; }

        /// <summary>
        /// Poststed
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Fritekst felt for ekstra beskrivelse. For eksempel ”Samme inngang som ICA, ta innerste dør til venstre”
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Hvorvidt adressen er arvet.
        /// </summary>
        [DataMember]
        public bool Inherited { get; set; }

        /// <summary>
        /// Landkode
        /// </summary>
        [DataMember]
        public Code Country { get; set; }

        public static Code CreateAddressTypeCode(string codeValue)
        {
            return new Code("adressetype", 3401, codeValue);
        }
    }
}