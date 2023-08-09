using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Åpningstider.
    /// </summary>
    /// <remarks>
    /// Åpningstidene skal holde informasjon om hvilke tidsperioder ("fra kl", "til kl")
    /// på hvilke ukedager som objektet den tilhører er åpent. Samtidig skal det være uavhengig
    /// av eksakte kalenderdatoer.
    ///
    /// Åpningstidene som defineres skal være relative til tidspunktet "mandag kl 00:00", som er
    /// definert som vårt . Med andre ord, se for deg at nullpunkttidspunktet akkurat nå er
    /// "midnatt natt til mandag" og du skal beskrive hvordan åpningstidene er den kommende uken.
    ///
    /// Syntaks er PnDTnHnM (basert på ISO8601):
    ///  - P definerer at dette er en varighet/periode og skal alltid være med
    ///  - nD beskriver antall dager fra vårt nullpunkt, som i praksis betyr ukedag. 0 = mandag, 1 = tirsdag, osv.
    ///  - T definerer at etterfølgende elementer omhandler tidspunkt og skal alltid være med
    ///  - nH beskriver antall timer fra vårt nullpunkt, i praksis timeangivelsen i åpningstiden
    ///  - nM beskriver antall minutter fra vårt nullpunkt, i praksis minuttangivelsen i åpningstiden
    /// </remarks>
    /// <example>
    /// Åpent mandager kl 0830 - 1500 som XML
    /// <code>
    /// <![CDATA[
    /// <OpeningHours>
    ///   <a:FreeText/>
    ///   <a:OpenAt>
    ///     <a:TimePeriod>
    ///       <a:From>PT8H30M</a:From>
    ///       <a:To>PT15H</a:To>
    ///     </a:TimePeriod>
    ///   </a:OpenAt>
    /// </OpeningHours>
    /// ]]>
    /// </code>
    /// </example>
    /// <example>
    /// Åpent mandager kl 0830 - 1500 som C# kode
    /// <code>
    /// <![CDATA[
    /// OpenAt = new[]
    /// {
    ///     new TimePeriod
    ///     {
    ///         From = new TimeSpan(0, 8, 30, 0),
    ///         To = new TimeSpan(0, 15, 0, 0)
    ///     }
    /// };
    /// ]]>
    /// </code>
    /// </example>
    /// <example>
    /// Åpent alle hverdager kl 0900 - 1600, og lørdager kl 1000 - 1330 som xml
    /// <code>
    /// <![CDATA[
    /// <OpeningHours>
    ///   <a:FreeText/>
    ///   <a:OpenAt>
    ///     <a:TimePeriod>
    ///       <a:From>PDT9H</a:From>
    ///       <a:To>PDT16H</a:To>
    ///     </a:TimePeriod>
    ///     <a:TimePeriod>
    ///       <a:From>P1DT9H</a:From>
    ///       <a:To>P1DT16H</a:To>
    ///     </a:TimePeriod>
    ///     <a:TimePeriod>
    ///       <a:From>P2DT9H</a:From>
    ///       <a:To>P2DT16H</a:To>
    ///     </a:TimePeriod>
    ///     <a:TimePeriod>
    ///       <a:From>P3DT9H</a:From>
    ///       <a:To>P3DT16H</a:To>
    ///     </a:TimePeriod>
    ///     <a:TimePeriod>
    ///       <a:From>P4DT9H</a:From>
    ///       <a:To>P4DT16H</a:To>
    ///     </a:TimePeriod>
    ///     <a:TimePeriod>
    ///       <a:From>P5DT10H</a:From>
    ///       <a:To>P5DT13H30M</a:To>
    ///     </a:TimePeriod>
    ///   </a:OpenAt>
    /// </OpeningHours>
    /// ]]>
    /// </code>
    /// </example>
    /// <example>
    /// Åpent alle hverdager kl 0900 - 1600, og lørdager kl 1000 - 1330 som C# kode
    /// <code>
    /// <![CDATA[
    /// OpenAt = new[]
    /// {
    ///     new TimePeriod
    ///     {
    ///         From = new TimeSpan(0, 9, 0, 0), To = new TimeSpan(0, 16, 0, 0)
    ///     },
    ///     new TimePeriod
    ///     {
    ///         From = new TimeSpan(1, 9, 0, 0), To = new TimeSpan(1, 16, 0, 0)
    ///     },
    ///     new TimePeriod
    ///     {
    ///         From = new TimeSpan(2, 9, 0, 0), To = new TimeSpan(2, 16, 0, 0)
    ///     },
    ///     new TimePeriod
    ///     {
    ///         From = new TimeSpan(3, 9, 0, 0), To = new TimeSpan(3, 16, 0, 0)
    ///     },
    ///     new TimePeriod
    ///     {
    ///         From = new TimeSpan(4, 9, 0, 0), To = new TimeSpan(4, 16, 0, 0)
    ///     },
    ///     new TimePeriod
    ///     {
    ///         From = new TimeSpan(5, 10, 0, 0), To = new TimeSpan(5, 13, 30, 0)
    ///     }
    /// };
    /// ]]>
    /// </code>
    /// </example>
    [DataContract(Namespace = Namespaces.CommonOldV1)]
    [Serializable]
    public class OpeningHours
    {
        /// <summary>
        /// Liste med angitte åpningstider. 
        /// </summary>
        [DataMember]
        public IList<TimePeriod> OpenAt { get; set; }

        /// <summary>
        /// Fritekstfelt for åpningstider
        /// </summary>
        [DataMember]
        public string FreeText { get; set; }

        /// <summary>
        /// Sjekker om to OpeningHours objekter er identiske
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var oh = obj as OpeningHours;
            return null == oh ? false : Equals(oh);
        }


        /// <summary>
        /// Hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var e1 = FreeText.GetHashCode();
            if (OpenAt != null && OpenAt.Count > 0)
            {
                e1 += OpenAt.Aggregate(e1, (hash, tp) => hash + tp.From.GetHashCode() + tp.To.GetHashCode());
            }

            return e1;
        }

        /// <summary>
        /// Sjekker om to OpeningHours objekter er identiske
        /// </summary>
        /// <param name="oh"></param>
        /// <returns></returns>
        public bool Equals(OpeningHours oh)
        {
            if (oh == null)
            {
                return false;
            }

            if (FreeText != oh.FreeText)
            {
                return false;
            }

            if (OpenAt.Count != oh.OpenAt.Count)
            {
                return false;
            }

            for (var i = 0; i < OpenAt.Count; i++)
            {
                if (OpenAt[i] != oh.OpenAt[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
