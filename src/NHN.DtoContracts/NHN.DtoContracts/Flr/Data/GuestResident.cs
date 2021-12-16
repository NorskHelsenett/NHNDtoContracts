using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    ///     <para>
    ///         En person som er bosatt i kommune A, men har fastlegen sin i kommune B er per definisjon en <i>gjesteinnbygger</i> i kommune B.
    ///     </para>
    ///     <para>
    ///         Eksempel: Jens er bosatt i Trondheim, men har sin fastlege i Verdal. Altså er Jens en gjesteinnbygger i Verdal.
    ///     </para>
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrV1)]
    [Serializable]
    public class GuestResident
    {
        /// <summary>
        /// Pasientens fødselsnummer.
        /// </summary>
        [DataMember]
        public string NIN { get; set; }

        /// <summary>
        /// Pasientens fornavn.
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Pasientens etternavn.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Kommunen hvor personen har sin bostedsadresse.
        /// </summary>
        [DataMember]
        public string Municipality { get; set; }

        /// <summary>
        /// Navnet på fastlegekontoret som personens fastlege arbeider ved.
        /// </summary>
        [DataMember]
        public string TreatmentCenter { get; set; }

        /// <summary>
        /// Kommunen fastlegekontoret ligger i.
        /// </summary>
        [DataMember]
        public string MunicipalityOfTreatmentCenter { get; set; }

        /// <summary>
        /// Telefonnummer til legekontoret.
        /// </summary>
        public string PhoneNumberOfTreatmentCenter { get; set; }

        /// <summary>
        /// Fastlegekontorets HerID.
        /// </summary>
        [DataMember]
        public int? HerIdOfTreatmentCenter { get; set; }

        /// <summary>
        /// Fastlegens fornavn.
        /// </summary>
        [DataMember]
        public string FirstNameOfGeneralPractitioner { get; set; }

        /// <summary>
        /// Fastlegens etternavn.
        /// </summary>
        [DataMember]
        public string LastNameOfGeneralPractitioner { get; set; }

        /// <summary>
        /// Fastlegens HPR-nummer.
        /// </summary>
        /// 
        [DataMember]
        public int? HPRNumberOfGeneralPractitioner { get; set; }
    }
}
