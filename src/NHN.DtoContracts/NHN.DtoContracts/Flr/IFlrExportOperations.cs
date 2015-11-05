using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr
{
    [ServiceContract(Namespace = FlrXmlNamespace.V1)]
    public interface IFlrExportOperations
    {
        /// <summary>
        /// Henter alle aktive fastlegelister.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<GPContract> ExportGPDetails();
    }
}
