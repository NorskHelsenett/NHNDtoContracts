using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// Data required when you add person to a 
    /// </summary>
    [DataContract(Namespace = OfrNamespace.Name)]
    public class AddPersonData
    {
        /// <summary>
        /// X
        /// </summary>
        [DataMember, Required]
        public string Nin { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public string ExternalRef { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember, Required]
        public DateTime StartPeriod { get; set; }
    }
}
