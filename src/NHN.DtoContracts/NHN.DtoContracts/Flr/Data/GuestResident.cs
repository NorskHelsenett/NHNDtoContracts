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
        /// Personens fødselsnummer.
        /// </summary>
        [DataMember]
        public string SSN { get; set; }

        /// <summary>
        /// Personens fornavn.
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Personens etternavn.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Kommunen hvor personen har sin bostedsadresse.
        /// </summary>
        [DataMember]
        public string Municipality { get; set; }

        /// <summary>
        /// Gatenavnet i bostedsadressen.
        /// </summary>
        [DataMember]
        public string StreetName { get; set; }

        /// <summary>
        /// Husnummeret i bostedsadressen.
        /// </summary>
        [DataMember]
        public string HouseLetter { get; set; }

        /// <summary>
        /// Navnet på fastlegekontoret som personens fastlege arbeider ved.
        /// </summary>
        [DataMember]
        public string TreatmentCenter { get; set; }

        /// <summary>
        /// Kommunen som fastlegekontoret ligger i.
        /// </summary>
        [DataMember]
        public string MunicipalityOfTreatmentCenter { get; set; }

        /// <summary>
        /// Fastlegekontorets organisasjonsnummer.
        /// </summary>
        [DataMember]
        public string OrganizationNumberOfTreatmentCenter { get; set; }

        /// <summary>
        /// Personens fastlege sitt fornavn.
        /// </summary>
        [DataMember]
        public string FirstNameOfGeneralPractitioner { get; set; }

        /// <summary>
        /// Personens fastlege sitt etternavn.
        /// </summary>
        [DataMember]
        public string LastNameOfGeneralPractitioner { get; set; }

        /// <summary>
        /// HPR-nummeret til personens fastlege.
        /// </summary>
        /// 
        [DataMember]
        public int HPRNumberOfGeneralPractitioner { get; set; }
    }
}
