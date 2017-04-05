using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Ofr.Data
{
    /// <summary>
    /// Objekt som representer et sett med personoppføringer i OFR, sammen med pagineringsinformasjon
    /// </summary>
    [DataContract(Namespace = OfrNamespace.Name)]
    public class PersonAssociations
    {
        /// <summary>
        /// Det paginerte resultatet av personer.
        /// </summary>
        [DataMember]
        public ICollection<PersonOnHealthRegister> Persons { get; set; }

        /// <summary>
        /// Det totalet antallet resultater.
        /// </summary>
        [DataMember]
        public int TotalEntries { get; set; }

        /// <summary>
        /// Sidenummere til det paginerte resultatet.
        /// </summary>
        [DataMember]
        public int Page { get; set; }

        /// <summary>
        /// Størrelsen til en side i det paginerte resultatet.
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
    }

    /// <summary>
    /// Objekt som representerer et sett med personoppføringer i OFR, sammen med pagineringsinformasjon, og error feedback
    /// Brukes i hovedsak ved DryRun metoder i OFR service.
    /// </summary>
    [DataContract(Namespace = OfrNamespace.Name)]
    public class PersonAssociationsWithErrors
    {
        /// <summary>
        /// Objektet som inneholder det paginerte resultatet av personer.
        /// </summary>
        [DataMember]
        public PersonAssociations Persons { get; set; }

        /// <summary>
        /// Listen av nins som ikke ble funnet i oppslag mot PREG.
        /// </summary>
        [DataMember]
        public ICollection<string> PersonNinsNotFound { get; set; }
    }
}
