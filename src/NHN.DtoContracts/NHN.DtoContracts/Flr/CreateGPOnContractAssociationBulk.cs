using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHN.DtoContracts.Flr
{
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class CreateGPOnContractAssociationBulk
    {
        [DataMember]
        public int GPContractId { get; set; }

        [DataMember]
        public GPOnContractAssociation GPOnContractAssociation { get; set; }
    }
}
