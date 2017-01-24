using NHN.DtoContracts.Common.en;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// X
    /// </summary>
    [DataContract(Namespace = OfrNamespace.Name)]
    public class PersonOnHealthRegister
    {
        /// <summary>
        /// X
        /// </summary>
        [DataMember, Required]
        public long Id { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember, Required]
        public string Nin { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public string ExternalRef { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public Period Period { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember, Required]
        public long HealthRegisterId { get; set; }

        /// <summary>
        /// Denne skal aldri settes ved skriving til registeret, men vil være tilgjengelig på
        /// operasjoner hvor perspektivet er en innbygger, f.eks GetHealthRegistersFor.
        /// </summary>
        [DataMember]
        public HealthRegister HealthRegister { get; set; }
    }
}
