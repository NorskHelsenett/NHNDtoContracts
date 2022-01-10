using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common
{
    [DataContract]
    public class FileResponse
    {
        [DataMember]
        [SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Data contracts are excepted")]
        public byte[] Bytes { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public string Filename { get; set; }

        [DataMember]
        public string MimeType { get; set; }
    }
}
