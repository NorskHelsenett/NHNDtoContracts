using System;
using System.IO;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using NHN.DtoContracts.Flr.Data;

namespace NHN.DtoContracts.Flr.Service
{
    /// <summary>
    /// Eksport av FLR.
    /// </summary>
    [ServiceContract(Namespace = FlrXmlNamespace.V1)]
    public interface IFlrExportOperations
    {
        /// <summary>
        /// Henter alle GPContracts gruppert pr kontor i en zip-fil
        /// Bruk søkeparametere for å begrense hva som blir eksportert
        /// </summary>
        /// <remarks>Søk etter leger</remarks>
        /// <param name="searchParameters">Begrenser innholdet i eksporten</param>
        /// <returns>>Zip file som stream.
        /// Innholdet i zip filen er en eller flere IList av GPContracts serialisert som xml
        /// Alle GPContracts i en IList tilhører samme kontor</returns>
        /// <exception cref="ArgumentException">Kastes hvis feil søkeparameter er oppgitt</exception>
        /// <example>
        /// <code>
        /// var zip = flrExportService.EXportGPContracts(searchCriteria);
        /// </code>
        /// </example>
        /// <permission>
        /// Krever en av rollene ADMINISTRATOR eller FLR_READ_ALL_PATIENTS
        /// </permission>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        Stream ExportGPContracts(ContractsQueryParameters searchParameters);
    }
}
