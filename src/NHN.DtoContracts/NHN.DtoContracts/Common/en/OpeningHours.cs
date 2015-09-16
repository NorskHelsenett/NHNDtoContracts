using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Åpningstider.
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglishOld)]
    public class OpeningHours
    {
        /// <summary>
        /// List med angitte åpningstider. 
        /// </summary>
        [DataMember]
        public IList<TimePeriod> OpenAt { get; set; }

        /// <summary>
        /// Fritekstfelt for åpningstider
        /// </summary>
        [DataMember]
        public string FreeText { get; set; }

        public override bool Equals(object obj)
        {
            var oh = obj as OpeningHours;
            if (null == oh)
                return false;
            return Equals(oh);
        }

        public override int GetHashCode()
        {
            var e1 = FreeText.GetHashCode();
            if (OpenAt != null && OpenAt.Count > 0)
                e1 += OpenAt.Aggregate(e1, (hash, tp) => hash + tp.From.GetHashCode() + tp.To.GetHashCode());

            return e1;
        }

        public bool Equals(OpeningHours oh)
        {
            if (FreeText != oh.FreeText)
                return false;
            if (OpenAt.Count != oh.OpenAt.Count)
                return false;
            for (var i = 0; i < OpenAt.Count; i++)
                if (OpenAt[i] != oh.OpenAt[i])
                    return false;

            return true;
        }
    }
}
