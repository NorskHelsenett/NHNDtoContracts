using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Beskriver en periode en lege er tilknyttet en GPContract.
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrV1)]
    [Serializable]
    public class GPOnContractAssociation
    {
        /// <summary>
        /// Denne ID'en eies av FLO.
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// Fremmednøkkel til GPContract.ID
        /// </summary>
        [DataMember]
        public long GPContractId { get; set; }

        /// <summary>
        /// Fastlegeavtale/liste. Satt ved lesing, må være null ved skriveoperasjoner.
        /// </summary>
        [DataMember]
        public GPContract GPContract { get; set; }

        /// <summary>
        /// HPR nummeret til legen
        /// </summary>
        [DataMember]
        public int HprNumber { get; set; }

        /// <summary>
        /// Må være Null ved skriving, vil være satt ved lesing når det er relevant.
        /// </summary>
        [DataMember]
        public Person GP { get; set; }

        /// <summary>
        /// Hvis satt, så representerer denne GPOnContract en vikar, og dette feltet viser for hvilken lege han er vikar.
        /// </summary>
        [DataMember]
        public int? SubstituteForHprNumber { get; set; } //VikarForLege

        /// <summary>
        /// Når er denne knytningen gyldig.
        /// </summary>
        [DataMember]
        public Period Valid { get; set; }

        /// <summary>
        /// Hvordan type knytning er dette mot GPContract.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/flrv2_relationship">flrv2_contract_relationship</see> (OID 7750).
        /// </summary>
        [DataMember]
        public Code Relationship { get; set; } //ForholdsKode;

        /// <summary>
        /// Tidspunkt data ble sist oppdatert
        /// </summary>
        [DataMember]
        public DateTimeOffset UpdatedOn { get; set; }
        /// <summary>
        /// Stillingsprosenten til legen.
        /// Når ulik null, må den være større enn 0 og mindre eller lik 100
        /// </summary>
        [DataMember]
        public int? WorkingPercentage { get; set; }

        /// <summary>
        /// Dagene legen jobber, 0 = søndag 1 = mandag (...) 6 = lørdag
        /// </summary>
        [DataMember]
        public List<DayOfWeek> WorkingOnDays { get; set; }
    }
}
