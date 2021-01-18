using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Logging.Data
{
    /// <summary>
    /// Logg av endringer i registerplattformen
    /// </summary>
    [DataContract(Namespace = Namespaces.LogFetchingV1)]
    [Serializable]
    public class EntityChangeLog
    {
        [DataMember]
        public string Info { get; set; }

        [DataMember]
        public Guid? UserId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public int? HerId{ get; set; }

        [DataMember]
        public int? OrgNr { get; set; }

        [DataMember]
        public int? ReshId { get; set; }

        [DataMember]
        public string IpAddress { get; set; }

        [DataMember]
        public IEnumerable<EntityChangeLogEntryData> Changes { get; set; }
    }
}
