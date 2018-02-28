using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Representerer koblingen mellom en pasient og en fastlegeliste.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    [Serializable]
    public class PatientToGPContractAssociation
    {
        /// <summary>
        /// Id til denne assosiasjonen. TilhørighetsId
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// ID til GPContract. Må være satt ved skriving, vil være satt ved lesing og vil være identisk med GPContract.Id.
        /// </summary>
        [DataMember]
        public long GPContractId { get; set; }

        /// <summary>
        /// Kontakten denne assosiasjonen peker til. Satt ved lesing, skal være null ved skriving.
        /// </summary>
        [DataMember]
        public GPContract GPContract { get; set; }

        /// <summary>
        /// HerId for adressering til fastlegetjenesten.
        /// Dette er HerId til fastlegen som er aktiv på listen på dagens dato, dersom en slik finnes.
        /// Hvis ikke returneres det HerId for fastlegelistens tjenestebaserte kommunikasjonspart av typen "Fastlege, liste uten fast lege", dersom en slik finnes definert på virksomhetsnivå.
        /// Returnerer NULL dersom passende HerId ikke finnes. 
        /// Feltet vil kun være satt for leseoperasjoner som spør på dagens dato, ikke på historiske data. Brukes ikke på skriveoperasjoner.
        /// </summary>
        [DataMember]
        public int? GPHerId { get; set; }

        /// <summary>
        /// Personnummer til innbygger
        /// </summary>
        [DataMember]
        public string PatientNIN { get; set; }

        /// <summary>
        /// Hvilken periode denne assosiasjonen er gyldig for.
        /// For Move metoden er dette perioden på den nye assosiasjonen. Den gamle assosiasjonen får TilDato satt til ny FraDato.
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
        public IList<GPOnContractAssociation> DoctorCycles { get; set; }

        /// <summary>
        /// Tidspunkt data ble sist oppdatert
        /// </summary>
        [DataMember]
        public DateTime UpdatedOn { get; set; }
    }
}