using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHN.DtoContracts.ServiceBus.Data
{
    /// <summary>
    /// Beskrivelse av et abonnement
    /// </summary>
    [DataContract(Namespace = Namespaces.ServiceBusManagerV1)]
    public class SubscriptionInfo
    {
        /// <summary>
        /// Navn på abonnement. 
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Path til topic for abonnement.
        /// </summary>
        [DataMember]
        public string TopicPath { get; set; }

        /// <summary>
        /// This property can be used for the calling system to identify different subscrptions on the same topic.
        /// </summary>
        [DataMember]
        public string UserSystemIdent { get; set;  }

        /// <summary>
        /// Gir full path til dette abonnement.
        /// </summary>
        public string FullPath => $"{TopicPath}/subscriptions/{Name}";
    }
}
