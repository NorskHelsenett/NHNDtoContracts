using NHN.DtoContracts.Flr.Service;
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
        /// Publiseres når en ny fastlegeavtale blir opprettet.
        /// 
        /// Se <see cref="IFlrWriteOperations.CreateGPContract" />.
        /// </summary>
        ContractCreated,

        /// <summary>
        /// Publiseres når en fastlegeavtale blir oppdatert med ny informasjon.
        /// 
        /// Se <see cref="IFlrWriteOperations.UpdateGPContract" />,
        /// <see cref="IFlrWriteOperations.UpdateGPContractMaxPatients" />,
        /// <see cref="IFlrWriteOperations.UpdateGPContractStatus" />,
        /// <see cref="IFlrWriteOperations.UpdateGPContractCoopMunicipalities" />,
        /// <see cref="IFlrWriteOperations.UpdateGPOfficeOnGPContracts" />.
        /// </summary>
        ContractUpdated,

        /// <summary>
        /// Publiseres når en fastlegeavtale blir avsluttet.
        /// 
        /// Se <see cref="IFlrWriteOperations.CancelGPContractAndMovePatients" />.
        /// </summary>
        ContractCanceled,

        /// <summary>
        /// Publiseres når en ny legeperiode blir koblet mot en fastlegeavtale.
        /// 
        /// Se <see cref="IFlrWriteOperations.CreateGPOnContractAssociation" />.
        /// </summary>
        GPOnContractCreated,

        /// <summary>
        /// Publiseres når en legeperiode blir oppdatert med ny informasjon.
        /// 
        /// Se <see cref="IFlrWriteOperations.UpdateGPOnContractAssociation" />.
        /// </summary>
        GPOnContractUpdated,

        /// <summary>
        /// Publiseres når en legeperiode blir slettet.
        /// 
        /// Se <see cref="IFlrWriteOperations.DeleteGPOnContractAssociation" />.
        /// </summary>
        GPOnContractDeleted,

        /// <summary>
        /// Publiseres når en pasient blir oppført på pasientlisten tilhørende en fastlegeavtale.
        /// 
        /// Se <see cref="IFlrWriteOperations.CreatePatientToGPContractAssociation" />,
        /// <see cref="IFlrWriteOperations.MovePatients" />,
        /// <see cref="IFlrWriteOperations.CancelGPContractAndMovePatients" />.
        /// </summary>
        PatientOnContractCreated,

        /// <summary>
        /// Publiseres når en pasient blir oppdatert med ny informasjon.
        /// 
        /// Se <see cref="IFlrWriteOperations.UpdatePatientNin"/>
        /// </summary>
        PatientOnContractUpdated,

        /// <summary>
        /// Publiseres når en pasient blir avsluttet på fastlegeavtalen.
        /// 
        /// Se <see cref="IFlrWriteOperations.CancelPatientOnGPContract" />, 
        /// <see cref="IFlrWriteOperations.CancelPatientsOnGPContract" />
        /// </summary>
        PatientOnContractCanceled,

        /// <summary>
        /// Publiseres når en pasients fødselsnummer blir endret.
        /// 
        /// Se <see cref="IFlrWriteOperations.UpdatePatientNin" />.
        /// </summary>
        PatientNinChanged,

        /// <summary>
        /// Publiseres når et nytt utekontor blir opprettet på en fastlegeavtale.
        /// 
        /// Se <see cref="IFlrWriteOperations.CreateOutOfOfficeLocation" />.
        /// </summary>
        OutOfOfficeLocationCreated,

        /// <summary>
        /// Publiseres når et utekontor blir oppdatert med ny informasjon.
        /// 
        /// Se <see cref="IFlrWriteOperations.UpdateOutOfOfficeLocation" />.
        /// </summary>
        OutOfOfficeLocationUpdated,

        /// <summary>
        /// Publiseres når et utekontor blir slettet.
        /// 
        /// Se <see cref="IFlrWriteOperations.RemoveOutOfOfficeLocation" />.
        /// </summary>
        OutOfOfficeLocationDeleted
    }
}
