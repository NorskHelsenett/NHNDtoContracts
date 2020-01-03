using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Representerer et fødselsnummer og et tidspunkt, brukes i spørringer mot FLR.
    /// </summary>
    [DataContract(Namespace = Namespaces.FlrV1)]
    public class NinWithTimestamp
    {
        /// <summary>
        /// Tom ctor
        /// </summary>
        public NinWithTimestamp()
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="nin">Fødselsnummer</param>
        /// <param name="atTime">Tidspunkt</param>
        public NinWithTimestamp(string nin, DateTime atTime)
        {
            NIN = nin;
            AtTime = atTime;
        }

        /// <summary>
        /// Fødselsnummer
        /// </summary>
        [DataMember]
        public string NIN { get; set; }

        /// <summary>
        /// Tidspunktet for gitt fødselsnummer en ønsker informasjon om.
        /// </summary>
        [DataMember]
        public DateTimeOffset AtTime { get; set; }
    }
}
