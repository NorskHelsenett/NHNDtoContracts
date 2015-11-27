using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Elektronisk adresse, f.eks. EDI, sertifikatpeker, telefonnummer, faxnummer, epost adresse.
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglishOld)]
    [Serializable]
    public class ElectronicAddress
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public ElectronicAddress()
        {
        }

        /// <summary>
        /// Oppretter en ElectronicAddress med gitt type
        /// </summary>
        /// <param name="type"></param>
        public ElectronicAddress(string type)
        {
            _type = CreateAddressTypeCode(type);
        }

        /// <summary>
        /// Dato og tid for siste endring til objektet
        /// </summary>
        [DataMember]
        public DateTime LastChanged { get; set; }

        /// <summary>
        /// OBSOLETE: Bruk Type istedet.
        /// Type elektronisk adresse
        /// Gyldige verdier: OID 9044 (verdiene som starter med E_)
        /// </summary>
        [Obsolete("Use Type instead")]
        [DataMember]
        public string TypeCodeValue
        {
            get { return _typeCodeValue; }
            set { _typeCodeValue = value; }
        }

        /// <summary>
        /// Type elektronisk adresse
        /// Gyldige verdier er fra OID 9044 (verdiene som starter med E_)
        /// </summary>
        [DataMember]
        public Code Type
        {
            get
            {
                if (_type == null && !string.IsNullOrEmpty(_typeCodeValue))
                    _type = new Code("type_adressekomponeneter", 9044, _typeCodeValue);

                return _type;
            }

            set
            {
                _type = value;
                if (_type != null && _typeCodeValue != _type.CodeValue)
                    _typeCodeValue = _type.CodeValue;
            }
        }
        private Code _type;
        private string _typeCodeValue;

        /// <summary>
        /// Verdien den elektroniske adressen er satt til.
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Indikerer om adressen er arvet fra overliggende enhet(er)
        /// </summary>
        [DataMember]
        public bool Inherited { get; set; }

        /// <summary>
        /// Lager Code objekt for gitte elektroniske adressetype.
        /// </summary>
        /// <param name="codeValue">E_TLF|E_ICE....</param>
        /// <returns>Kodeobjekt. Description vil ikke være satt.</returns>
        public static Code CreateAddressTypeCode(string codeValue)
        {
            return new Code("type_adressekomponeneter", 9044, codeValue);
        }
    }
}
