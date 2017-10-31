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
        /// <param name="parameter" cref="RequestTrackedLogQueryParameters">Parametre for å utføre søk på forespørsler</param>
        /// <returns cref="RequestTrackedLog">Paginert liste over forespørsler. se også <see cref="ResultWithPagination{T}"/></returns>
        /// <permission>
        /// Krever en av rollene ADMINISTRATORfor gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ResultWithPagination<RequestTrackedLog> GetRequestTracedLogs(RequestTrackedLogQueryParameters parameter);

        /// <summary>
        /// Henter ut loggende forespørseler mot fastlegereigstret (Flr). 
        /// Dette gjelder da forespørseler til Flr tjenestene FlrReadOperationService og FlrExportService. 
        /// </summary>
        /// <param name="parameter" cref="RequestTrackedLogQueryParameters">Parametre for å utføre søk på forespørsler. Parameteret ServiceName vil her være begrenset til Flr relaterte tjenester.</param>
        /// <returns cref="RequestTrackedLog">Paginert liste over forespørsler. se også <see cref="ResultWithPagination{T}"/></returns>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ_REQUEST_TRACKED_LOG for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ResultWithPagination<RequestTrackedLog> GetFlrRequestTracedLogs(RequestTrackedLogQueryParameters parameter);
    }
}
