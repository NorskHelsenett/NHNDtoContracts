using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Brukes kun av NAV.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
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
        /// Sertifikat som skal brukes for å kryptere innholdet. I betaversjon: Må være satt til null. I ikke-beta: Påkrevd.
        /// </summary>
        [DataMember]
        public byte[] EncryptWithX509Certificate { get; set; }

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
        /// Se Senderxml for prinsipp.
        /// </summary>
        [DataMember]
        public string ReceiverXml { get; set; }

        /// <summary>
        /// Om det diskettformat "disk" eller XML "xml". Påkrevd.
        /// </summary>
        [DataMember]
        public string ListType { get; set; }
    }
}
