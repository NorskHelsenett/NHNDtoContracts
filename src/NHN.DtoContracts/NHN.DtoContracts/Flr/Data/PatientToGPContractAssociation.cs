using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Representerer koblingen mellom en pasient og til en fastlegeliste.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class PatientToGPContractAssociation
    {
        /// <summary>
        /// Id til denne assiosasjonen. TilhørighetsId
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// ID til GPContract. Må være satt ved skriving, vil være satt ved lesing og vil være identisk med GPContract.Id.
        /// </summary>
        [DataMember]
        public long GPContractId { get; set; }

        /// <summary>
        ///  Kontakten denne assoisasjonen peker til. Satt ved lesing, skal være null ved skriving.
        /// </summary>
        [DataMember]
        public GPContract GPContract { get; set; }

        /// <summary>
        /// Personnummer til innbygger
        /// </summary>
        [DataMember]
        public string PatientNIN { get; set; }

        /// <summary>
        /// For hvilken periode er denne assiosasjonen gyldig?
        /// For Move metoden så er FraDato -> fradatoen til nye tilhørigheten, TilDato -> tildatoen til den gamle.
        /// </summary>
        [DataMember]
        public Period Period { get; set; } //FraDato ?TilDato;

        /// <summary>
        /// Kode på hvorfor perioden er endret (avsluttet). Er NULL normalt sett med mindre personen har forlatt ordningen.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/flrv2_endreason">flrv2_endreason</see> (OID 7753).
        /// </summary>
        [DataMember]
        public Code EndCode { get; set; }

        /// <summary>
        /// Kode på hvorfor perioden er startet.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/flrv2_beginreason">flrv2_beginreason</see> (OID 7754).
        /// </summary>
        [DataMember]
        public Code BeginCode { get; set; }

        /// <summary>
        /// Detaljer om pasienten. Dette vil være satt på leseoperasjoner når det er relevant, men må være NULL på skriveoperasjoner.
        /// </summary>
        [DataMember]
        public Person Patient { get; set; }

        /// <summary>
        /// Legeperioder som overlapper med denne pasientperioden på listen. Dette vil være satt på leseoperasjoner når det er relevant, 
        /// men må være NULL på skriveoperasjoner.
        /// </summary>
        [DataMember]
        public ICollection<GPOnContractAssociation> DoctorCycles { get; set; }

        /// <summary>
        /// Tidspunkt data ble sist oppdatert
        /// </summary>
        [DataMember]
        public DateTime UpdatedOn { get; set; }
    }
}