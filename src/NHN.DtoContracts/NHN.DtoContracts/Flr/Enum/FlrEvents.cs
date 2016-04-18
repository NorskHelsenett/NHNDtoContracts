using NHN.DtoContracts.ServiceBus.Service;

namespace NHN.DtoContracts.Flr.Enum
{
    /// <summary>
    /// Alle eventName typene som blir brukt av <see cref="IServiceBusManager"/>
    /// der eventSource er "flr"
    /// </summary>
    public enum FlrEvents
    {
        /// <summary>
        /// Ny kontrakt er lagt til
        /// </summary>
        ContractCreated,
        /// <summary>
        /// En kontrakt er oppdatert
        /// </summary>
        ContractUpdated,
        /// <summary>
        /// En kontrakt er kanselert
        /// </summary>
        ContractCanceled,
        /// <summary>
        /// Lege er lagt til en kontrakt
        /// </summary>
        GPOnContractCreated,
        /// <summary>
        /// Lege koblet til kontrakt er oppdatert
        /// </summary>
        GPOnContractUpdated,
        /// <summary>
        /// Lege er slettet fra kontrakt
        /// </summary>
        GPOnContractDeleted,
        /// <summary>
        /// Pasient er lagt til kontrakt
        /// </summary>
        PatientOnContractCreated,
        /// <summary>
        /// Pasient på kontrakt er forandret
        /// </summary>
        PatientOnContractUpdated,
        /// <summary>
        /// Pasient er kanselert på kontrakt
        /// </summary>
        PatientOnContractCanceled,
        /// <summary>
        /// Pasient sin SSN er forandret
        /// </summary>
        PatientNinChanged,
        /// <summary>
        /// Utekontor er lagt til
        /// </summary>
        OutOfOfficeLocationCreated,
        /// <summary>
        /// Utekontor er forandret
        /// </summary>
        OutOfOfficeLocationUpdated,
        /// <summary>
        /// Utekontor er slettet
        /// </summary>
        OutOfOfficeLocationDeleted
    }
}
