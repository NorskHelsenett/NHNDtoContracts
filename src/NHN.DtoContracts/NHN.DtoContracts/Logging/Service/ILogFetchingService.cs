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
        /// <returns cref="RequestTrackedLog">Paginert liste over forespørsler. Se også <see cref="ResultWithPagination{T}"/></returns>
        /// <exception cref="System.ArgumentException">Kastes hvis RequetedPeriod i RequestTrackedLogQueryParameters ikke er definert eller er ugyldig</exception>
        /// <example>
        /// <code language="C#">
        /// 
        /// var query = new RequestTrackedLogQueryParameters
        ///        {
        ///            RequestedBy = "userName",
        ///            RequestedPeriod = new DtoContracts.Common.en.Period { From = DateTime.Now.AddDays(-2), To = DateTime.Now.AddDays(2) }
        ///        };
        ///        
        /// var logs = _logFetchingService.GetRequestTracedLogs(query);
        /// 
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ResultWithPagination<RequestTrackedLog> GetRequestTracedLogs(RequestTrackedLogQueryParameters parameter);

        /// <summary>
        /// Henter ut loggende forespørseler mot fastlegereigstret (Flr). 
        /// Dette gjelder da forespørseler til Flr tjenestene FlrReadOperationService og FlrExportService. 
        /// </summary>
        /// <param name="parameter" cref="RequestTrackedLogQueryParameters">Parametre for å utføre søk på forespørsler. Parameteret ServiceName vil her være begrenset til Flr relaterte tjenester.</param>
        /// <returns cref="RequestTrackedLog">Paginert liste over forespørsler. Se også <see cref="ResultWithPagination{T}"/></returns>
        /// <exception cref="System.ArgumentException">Kastes hvis RequetedPeriod i RequestTrackedLogQueryParameters ikke er definert eller er ugyldig</exception>
        /// <exception cref="System.ArgumentException">Kastes hvis ServiceName i RequestTrackedLogQueryParameters ikke minimum starter på Flr</exception>
        /// <example>
        /// <code language="C#">
        /// 
        /// var query = new RequestTrackedLogQueryParameters
        ///        {
        ///            RequestedPeriod = new DtoContracts.Common.en.Period { From = DateTime.Now.AddDays(-2), To = DateTime.Now.AddDays(2) },
        ///            ServiceName = "FlrReadOperationsService",
        ///            MethodName = "GetGPContract"
        ///        };
        ///        
        /// var logs = _logFetchingService.GetFlrRequestTracedLogs(query);
        /// 
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ_REQUEST_TRACKED_LOG for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ResultWithPagination<RequestTrackedLog> GetFlrRequestTracedLogs(RequestTrackedLogQueryParameters parameter);

        /// <summary>
        /// Henter ut loggende forespørseler mot fastlegereigstret (Flr) basert på predefinerte parametrer som er trekt ut av <see cref="RequestTrackedLog.RequestParameters"/>.
        /// Dette gjelder forespørseler til Flr tjenestene FlrReadOperationService og FlrExportService.
        /// </summary>
        /// <param name="parameter" cref="RequestTrackedLogQueryParameters">Parametre for å utføre søk på forespørsler. Parameteret ServiceName vil her være begrenset til Flr relaterte tjenester.</param>
        /// <param name="parameterType">Prederefinert felt type. F.eks "ContractId", "Month","OrganizationNumber". Påkrevd om ikke parameterValue er definert</param>
        /// <param name="parameterValue">Verdien i feltet. Verdien vil ha en sting format som paremeteret hadde ved forespørselen. Påkrevd om ikke parameterType er definert</param>
        /// <returns cref="RequestTrackedLog">Paginert liste over forespørsler. se også <see cref="ResultWithPagination{T}"/></returns>
        /// <exception cref="System.ArgumentException">Kastes hvis RequetedPeriod i RequestTrackedLogQueryParameters ikke er definert eller er ugyldig</exception>
        /// <exception cref="System.ArgumentException">Kastes hvis ServiceName i RequestTrackedLogQueryParameters ikke minimum starter på Flr</exception>
        /// <example>
        /// <code language="C#">
        /// 
        /// var query = new RequestTrackedLogQueryParameters
        ///        {
        ///            RequestedPeriod = new DtoContracts.Common.en.Period { From = DateTime.Now.AddDays(-2), To = DateTime.Now.AddDays(2) },
        ///            ServiceName = "Flr"
        ///        };
        ///        
        /// var requestsWithContractIdParameter     = _logFetchingService.GetFlrRequestTracedLogsByParameterTypeAndValue(query, "ContractId","1234");
        /// var requestsWithMonthParameter          = _logFetchingService.GetFlrRequestTracedLogsByParameterTypeAndValue(query, "Month","01.11.2017 00:00:00");
        /// var requestsWithOrganizationParameter   = _logFetchingService.GetFlrRequestTracedLogsByParameterTypeAndValue(query, "OrganizationNumber","11111");
        /// var requestsWithDoctorNinParameter      = _logFetchingService.GetFlrRequestTracedLogsByParameterTypeAndValue(query, "DoctorNIN","22222");
        /// var requestsWithMunicipalityIdParameter = _logFetchingService.GetFlrRequestTracedLogsByParameterTypeAndValue(query, "MunicipalityId","233");
        /// 
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ_REQUEST_TRACKED_LOG for gjeldende register.
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ResultWithPagination<RequestTrackedLog> GetFlrRequestTrackedLogsByParameterTypeAndValue(RequestTrackedLogQueryParameters parameter, string parameterType, string parameterValue);

    }
}
