using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr
{
    /// <summary>
    /// Representerer informasjon om et utekontor
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class OutOfOfficeLocation
    {
        /// <summary>
        /// ID. This Id is owned by FLO.
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// ID til GPContract
        /// </summary>
        [DataMember]
        public long GPContractId { get; set; }
        
        /// <summary>
        /// Beskrivelse av utekontoret
        /// </summary>
        [DataMember]
        public string Description { get; set; } 

        /// <summary>
        /// Adressen til utekontoret. Kan være både besøksadresse (RES)  og/eller Postadresse (PST)
        /// </summary>
        [DataMember]
        public List<PhysicalAddress> Addresses { get; set; }

        /// <summary>
        /// Postadressen til utekontoret.
        /// </summary>
        [DataMember]
        public PhysicalAddress PostalAddress { get; set; }

        /// <summary>
        /// Telefonnummer til utekontoret.
        /// </summary>
        [DataMember]
        public string TelephoneNumber{ get; set; }

        /// <summary>
        /// For hvilken periode er dette utekontoret relevant
        /// </summary>
        [DataMember]
        public Period Valid { get; set; }
    }
}
