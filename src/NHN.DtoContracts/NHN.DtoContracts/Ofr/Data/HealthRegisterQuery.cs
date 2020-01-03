using NHN.DtoContracts.Common.en;
using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// Søkeparametre for å hente ut helseregisteroppføringer i OFR
    /// </summary>
    [DataContract(Namespace = Namespaces.OfrV1)]
    public class HealthRegisterQuery
    {
        /// <summary>
        /// Fritekstsøk felt for OFR, søker på Name og DisplayName for oppføringen, samt Name og DisplayName for enheten som eier oppføringen
        /// </summary>
        [DataMember]
        public string FullText { get; set; }

        /// <summary>
        /// Søkefelt for å hente helseregisteroppføringer basert på orgnummer til enheten som eier oppføringene
        /// </summary>
        [DataMember]
        public int? BelongsToOrg { get; set; }

        /// <summary>
        /// Felt for å hente ut helseregisteroppføringer basert på Type, representer av en kode i et kodeverk
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/ofr_helseregistertype">ofr_helseregistertype</see>.
        /// </summary>
        [DataMember]
        public Code Type { get; set; }

        /// <summary>
        /// Hvis null, returnerer historiske. Hvis satt, returnerer kontrakter som var gyldige på gitt tidspunkt.
        /// </summary>
        [DataMember]
        public DateTimeOffset? WasActiveAtTime { get; set; }
    }
}
