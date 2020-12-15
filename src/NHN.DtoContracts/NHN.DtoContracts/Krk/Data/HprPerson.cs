using System.Runtime.Serialization;

namespace NHN.DtoContracts.Krk.Data
{
    public class HprPerson
    {
        /// <summary>
        /// Helsepersonellnummer
        /// </summary>
        [DataMember]
        public int HprNumber { get; set; }

        /// <summary>
        /// Navnet på helsepersonen
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
