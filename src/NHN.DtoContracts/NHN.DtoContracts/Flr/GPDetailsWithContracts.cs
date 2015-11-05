using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Flr
{
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class GPDetailsWithContracts : GPDetails
    {
        [DataMember]
        public ICollection<GPOnContractAssociation> Contracts { get; set; }
    }
}