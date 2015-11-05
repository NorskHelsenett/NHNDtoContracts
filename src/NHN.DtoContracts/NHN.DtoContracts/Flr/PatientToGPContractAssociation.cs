using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr
{
    /// <summary>
    /// Representerer koblingen mellom en pasient og til en fastlegeliste.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class PatientToGPContractAssociation
    {
        /// <summary>
        /// Id til denne assiosasjonen.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// ID til GPContract
        /// </summary>
        [DataMember]
        public int GPContractId { get; set; }

        /// <summary>
        /// Personnummer til innbygger
        /// </summary>
        [DataMember]
        public string PatientSSN { get; set; }

        /// <summary>
        /// For hvilken periode er denne assiosasjonen gyldig?
        /// </summary>
        [DataMember]
        public Period Period { get; set; } //FraDato ?TilDato;

        /// <summary>
        /// Kode på hvorfor perioden er endret (avsluttet).
        /// </summary>
        [DataMember]
        public Code LastChangeCode { get; set; }

        /// <summary>
        /// Detaljer om pasienten. Dette vil være satt på leseoperasjoner når det er relevant, men må være NULL på skriveoperasjoner.
        /// </summary>
        [DataMember]
        public Person Patient { get; set; }

        /// <summary>
        /// Detaljer om legen tilknyttet denne assiosasjonen. Denne er satt ved lesing når det er relevant, men Skal være null ved skriving.
        /// </summary>
        [DataMember]
        public GPDetails GPDetails { get; set; }
    }
}