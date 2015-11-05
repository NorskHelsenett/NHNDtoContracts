using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr
{
    [ServiceContract(Namespace = FlrXmlNamespace.V1)]
    public interface IFlrReadOperations
    {
        /// <summary>
        /// Henter fastlege for en gitt person.
        /// </summary>
        /// <param name="patientNin"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPDetails GetPatientGPDetails(string patientNin);

        /// <summary>
        /// Henter fastlegebytte historikken
        /// </summary>
        /// <param name="patientNin"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<PatientToGPContractAssociation> GetPatientGPHistory(string patientNin);

        /// <summary>
        /// Henter en enkelt fastlegeavtale
        /// </summary>
        /// <param name="gpContractId">Kontraktens id.</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPContract GetGPContract(int gpContractId);

        /// <summary>
        /// Henter fastlegeavtaler tilknyttet virksomheten.
        /// </summary>
        /// <param name="organizationNumber"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<GPContract> GetGPContractsOnOffice(string organizationNumber);

        /// <summary>
        /// Henter fastlegeliste.
        /// </summary>
        /// <param name="gpContractId">Fastlegeavtalen.</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<PatientToGPContractAssociation> GetGPPatientList(int gpContractId);

        /// <summary>
        /// Henter fastlege og tilhørende praksis(er)
        /// </summary>
        /// <param name="hprNumber">Legens HPR-nummer.</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPDetailsWithContracts GetGPWithAssociatedGPContracts(int hprNumber);
    }
}
