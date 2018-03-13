using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Fysisk adresse, f.eks. besøks-, post- eller fakturaadresse.
    /// </summary>
    [DataContract(Namespace = Namespaces.CommonOldV1)]
    [Serializable]
    public class PhysicalAddress
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PhysicalAddress()
        {
        }

        /// <summary>
        /// Ctor med gitt Type.CodeValue
        /// </summary>
        /// <param name="codeValue"></param>
        public PhysicalAddress(string codeValue)
        {
            _type = CreateAddressTypeCode(codeValue);
        }

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
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/adressetype">adressetype</see> (OID 3401).
        /// </summary>
        [DataMember]
        public Code Type
        {
            get { return _type; }
            set { _type = value; }
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
        /// Landkode.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/landkoder">landkoder</see> (OID 9043).
        /// </summary>
        [DataMember]
        public Code Country { get; set; }

        /// <summary>
        /// Kommune.  <see href="/CodeAdmin/EditCodesInGroup/kommune">kommune</see> (OID 3402).
        /// </summary>
        [DataMember]
        public Code Municipality { get; set; }

        /// <summary>
        /// Opprette Code for en fysisk adresse basert på adresssens kodeveri..
        /// </summary>
        /// <param name="codeValue"></param>
        /// <returns></returns>
        public static Code CreateAddressTypeCode(string codeValue)
        {
            return new Code("adressetype", 3401, codeValue);
        }
    }
}