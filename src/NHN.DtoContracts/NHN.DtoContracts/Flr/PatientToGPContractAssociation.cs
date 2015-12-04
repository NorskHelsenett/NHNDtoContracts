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
        /// Id til denne assiosasjonen. TilhørighetsId.
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
        /// For Move metoden så er FraDato -> fradatoen til nye tilhørigheten, TilDato -> tildatoen til den gamle.
        /// </summary>
        [DataMember]
        public Period Period { get; set; } //FraDato ?TilDato;

        /// <summary>
        /// Kode på hvorfor perioden er endret (avsluttet).
        /// For Move metoden så er LastChangeCode -> OpprettelsesKode for ny tilhørigheten
        /// </summary>
        [DataMember]
        public Code LastChangeCode { get; set; }
    }
}
