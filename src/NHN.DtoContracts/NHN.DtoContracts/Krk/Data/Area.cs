using System.Runtime.Serialization;

namespace NHN.DtoContracts.Krk.Data
{
    /// <summary>
    /// Et area kan være et fylke, en kommune eller en bydel. Dette objektet brukes for å samle informasjon om
    /// navn og identifikator
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Identifikatoren til området. Typisk kommune- eller bydelsnummer
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Navnet på fylket, kommunen eller bydelen
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
