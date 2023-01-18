using NHN.DtoContracts.Flr.Service;
using NHN.DtoContracts.ServiceBus.Service;

namespace NHN.DtoContracts.Flr.Enum
{
    /// <summary>
    /// Alle eventName typene som blir brukt av <see cref="IServiceBusManagerV2"/>
    /// der eventSource er "flr"
    /// </summary>
    public enum FlrEvents
    {
        /// <summary>
        /// Publiseres n�r en ny fastlegeavtale blir opprettet.
        ///
        /// Se <see cref="IFlrWriteOperations.CreateGPContract" />.
        /// </summary>
        ContractCreated,

        /// <summary>
        /// Publiseres n�r en fastlegeavtale blir oppdatert med ny informasjon.
        ///
        /// Se <see cref="IFlrWriteOperations.UpdateGPContract" />,
        /// <see cref="IFlrWriteOperations.UpdateGPContractMaxPatients" />,
        /// <see cref="IFlrWriteOperations.UpdateGPContractPatientsOnWaitingList"/>,
        /// <see cref="IFlrWriteOperations.UpdateGPContractStatus" />,
        /// <see cref="IFlrWriteOperations.UpdateGPContractCoopMunicipalities" />,
        /// <see cref="IFlrWriteOperations.UpdateGPOfficeOnGPContracts" />.
        /// </summary>
        ContractUpdated,

        /// <summary>
        /// Publiseres n�r en fastlegeavtale blir avsluttet.
        ///
        /// Se <see cref="IFlrWriteOperations.CancelGPContractAndMovePatients" />.
        /// </summary>
        ContractCanceled,

        /// <summary>
        /// Publiseres n�r en ny legeperiode blir koblet mot en fastlegeavtale.
        ///
        /// Se <see cref="IFlrWriteOperations.CreateGPOnContractAssociation" />.
        /// </summary>
        GPOnContractCreated,

        /// <summary>
        /// Publiseres n�r en legeperiode blir oppdatert med ny informasjon.
        ///
        /// Se <see cref="IFlrWriteOperations.UpdateGPOnContractAssociation" />.
        /// </summary>
        GPOnContractUpdated,

        /// <summary>
        /// Publiseres n�r en legeperiode blir slettet.
        ///
        /// Se <see cref="IFlrWriteOperations.DeleteGPOnContractAssociation" />.
        /// </summary>
        GPOnContractDeleted,

        /// <summary>
        /// Publiseres n�r en pasient blir oppf�rt p� pasientlisten tilh�rende en fastlegeavtale.
        ///
        /// Se <see cref="IFlrWriteOperations.CreatePatientToGPContractAssociation" />,
        /// <see cref="IFlrWriteOperations.MovePatients" />,
        /// <see cref="IFlrWriteOperations.CancelGPContractAndMovePatients" />.
        /// </summary>
        PatientOnContractCreated,

        /// <summary>
        /// Publiseres n�r en pasient blir oppdatert med ny informasjon.
        ///
        /// Se <see cref="IFlrWriteOperations.UpdatePatientNin"/>
        /// </summary>
        PatientOnContractUpdated,

        /// <summary>
        /// Publiseres n�r en pasient blir avsluttet p� fastlegeavtalen.
        ///
        /// Se <see cref="IFlrWriteOperations.CancelPatientOnGPContract" />,
        /// <see cref="IFlrWriteOperations.CancelPatientsOnGPContract" />
        /// </summary>
        PatientOnContractCanceled,

        /// <summary>
        /// Publiseres n�r en pasients f�dselsnummer blir endret.
        ///
        /// Se <see cref="IFlrWriteOperations.UpdatePatientNin" />.
        /// </summary>
        PatientNinChanged,

        /// <summary>
        /// Publiseres n�r et nytt utekontor blir opprettet p� en fastlegeavtale.
        ///
        /// Se <see cref="IFlrWriteOperations.CreateOutOfOfficeLocation" />.
        /// </summary>
        OutOfOfficeLocationCreated,

        /// <summary>
        /// Publiseres n�r et utekontor blir oppdatert med ny informasjon.
        ///
        /// Se <see cref="IFlrWriteOperations.UpdateOutOfOfficeLocation" />.
        /// </summary>
        OutOfOfficeLocationUpdated,

        /// <summary>
        /// Publiseres n�r et utekontor blir slettet.
        ///
        /// Se <see cref="IFlrWriteOperations.RemoveOutOfOfficeLocation" />.
        /// </summary>
        OutOfOfficeLocationDeleted
    }
}
