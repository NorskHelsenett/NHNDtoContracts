using System.Runtime.Serialization;
using NHN.DtoContracts;

namespace NHN.DtoContracts.Logging.Data
{
    [DataContract(Namespace = Namespaces.CommonOldV1)]
    public class EntityChangeLogEntryData
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string OldValue { get; set; }
        [DataMember]
        public string NewValue { get; set; }
    }
}
