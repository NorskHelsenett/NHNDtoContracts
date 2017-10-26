using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.Logging.Data;

namespace NHN.DtoContracts.Logging.Service
{
    /// <summary>
    /// Tjeneste for å hente ut log fra registerplatformen
    /// </summary>
    [ServiceContract(Namespace = LogFetchingNamespace.Name)]
    public interface ILogFetchingService
    {
        /// <summary>
        /// Hente ut loggende forespørsler
        /// </summary>
        /// <param name="parameter" cref="RequestTrackedLogQueryParameters"></param>
        /// <returns cref="RequestTrackedLog">RequestTrackedLog med RequestTrackedLog</returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ResultWithPagination<RequestTrackedLog> GetRequestTracedLogs(RequestTrackedLogQueryParameters parameter); 
    }
}
