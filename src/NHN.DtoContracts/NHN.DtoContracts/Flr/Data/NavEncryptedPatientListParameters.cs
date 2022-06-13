using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Brukes kun av NAV.
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrV1)]
    public class NavEncryptedPatientListParameters
    {
        /// <summary>
        /// Legens personnummer. Påkrevd.
        /// </summary>
        [DataMember]
        public string DoctorNIN { get; set; }

        /// <summary>
        /// Kommunenummer legen opererer i. Påkrevd.
        /// </summary>
        [DataMember]
        public string MunicipalityId { get; set; }

        /// <summary>
        /// Sertifikatet som skal brukes for å kryptere innholdet i form av en byte[].
        /// Vi bruker X.509 sertifikater.
        /// </summary> 
        [DataMember]
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] EncryptWithX509Certificate { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Måneden uttrekket skal gjelde for. Dette feltet må være den første i måneden man ønsker, med tidsstempesl satt til 0. Påkrevd
        /// Med andre ord: Month kan f.eks være 2016-03-01 00:00:00 men IKKE 2016-03-02 00:00:01.
        /// </summary>
        [DataMember]
        public DateTime Month { get; set; }

        /// <summary>
        /// Boolsk verdi som indikerer hvorvidt legen angitt i <see cref="DoctorNIN">DoctorNIN</see> kan være en vikar.
        /// </summary>
        [DataMember]
        public bool DoSubstituteSearch { get; set; }

        /// <summary>
        /// XML av MsgHead.MsgInfo.Sender objektet. Merk at xmlns:mh må være med. Påkrevd
        /// </summary>
        /// <example>
        /// <code language="xml">
        /// <![CDATA[
        /// <mh:Sender xmlns:mh=""http://www.kith.no/xmlstds/msghead/2006-05-24"">
        /// <mh:Organisation>
        /// <mh:OrganisationName>NAV</mh:OrganisationName>
        /// <mh:Ident>
        /// <mh:Id>889640782</mh:Id>
        /// <mh:TypeId DN = ""Organisasjonsnummeret i Enhetsregisteret"" S=""2.16.578.1.12.4.1.1.9051"" V=""ENH""/>
        /// </mh:Ident>
        /// <mh:Ident>
        /// <mh:Id>79768</mh:Id>
        /// <mh:TypeId DN = ""Identifikator fra Helsetjenesteenhetsregisteret(HER-id)"" S=""2.16.578.1.12.4.1.1.9051"" V=""HER""/>
        /// </mh:Ident>
        /// </mh:Organisation>
        /// </mh:Sender>
        /// ]]>
        /// </code>
        /// </example>
        [DataMember]
        public string SenderXml { get; set; }

        /// <summary>
        /// XML av MsgHead.MsgInfo.Receiver objektet. Merk at xmlns:mh må være med. Påkrevd
        /// Se <see cref="SenderXml">SenderXml</see> for prinsipp.
        /// </summary>
        [DataMember]
        public string ReceiverXml { get; set; }

        /// <summary>
        /// Om det diskettformat "disk" eller XML "xml". Påkrevd.
        /// </summary>
        [DataMember]
        public string ListType { get; set; }

        /// <summary>
        /// Primært for å hente innholdet i objektet ved logging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"DoctorNIN: {DoctorNIN}; MunicipalityId: {MunicipalityId}; Month: {Month}; DoSubstituteSearch: {DoSubstituteSearch}; FormatType: {ListType}";
        }
    }
}
