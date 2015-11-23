using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Generisk feilmelding.
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglishOld)]
    public class GenericFault
    {
        /// <summary>
        /// Feilmeldingskode
        /// </summary>
        [DataMember]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Beskrivelse av feilen
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        private GenericFault(string errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Create new faultexception og GenericFault type
        /// </summary>
        /// <param name="errorCode">Error code</param>
        /// <param name="message">Error message</param>
        /// <returns>The FE</returns>
        public static FaultException<GenericFault> Create(string errorCode, string message)
        {
            var fault = new GenericFault(errorCode, message);
            return new FaultException<GenericFault>(fault, fault.Message);
        }
    }
}
