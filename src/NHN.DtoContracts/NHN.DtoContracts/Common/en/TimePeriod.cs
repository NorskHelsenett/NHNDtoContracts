using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// En tidsperiode uten informasjon om dato.
    /// Implementerer IComparable for sortering, hvor det sorteres på Fra og så Til.
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglishOld)]
    [Serializable]
    public struct TimePeriod : IComparable<TimePeriod>
    {
        /// <summary>
        /// Oppretter en ny tildsperiode med spesifiserte data
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static TimePeriod FromHours(double from, double to)
        {
            return new TimePeriod(TimeSpan.FromHours(from), TimeSpan.FromHours(to));
        }

        /// <summary>
        /// Oppretter en ny tildsperiode med spesifiserte data
        /// </summary>
        public static TimePeriod FromMinutes(int from, int to)
        {
            return new TimePeriod(TimeSpan.FromMinutes(from), TimeSpan.FromMinutes(to));
        }

        /// <summary>
        /// Oppretter en ny tildsperiode med spesifiserte data
        /// </summary>
        public TimePeriod(TimeSpan from, TimeSpan to)
        {
            if (to < from)
                throw new ArgumentException($"To ({to}) can not be less than From ({from})");

            From = from;
            To = to;
        }

        /// <summary>
        /// Hvor lang tidsperidoe?
        /// </summary>
        public TimeSpan Length => To - From;

        /// <summary>
        /// Tidsperiode fra
        /// </summary>
        [DataMember]
        public TimeSpan From { get; private set; }

        /// <summary>
        /// Tidsperiode til
        /// </summary>
        [DataMember]
        public TimeSpan To { get; private set; }

        /// <summary>
        /// Sammenlikner to TimePeriode objekter for sortering
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TimePeriod other)
        {
            var result = From.CompareTo(other.From);
            return result != 0 ? result : To.CompareTo(other.To);
        }

        /// <summary>
        /// Sjekker om to tidsperioder er like.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            return ((TimePeriod)obj) == this;
        }

        /// <summary>
        /// Hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return From.GetHashCode() + To.GetHashCode();
        }


        /// <summary>
        /// Likhetsjekk
        /// </summary>
        public static bool operator ==(TimePeriod tp1, TimePeriod tp2)
        {
            return tp1.From == tp2.From && tp1.To == tp2.To;
        }

        /// <summary>
        /// Likhetssjekk.
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns></returns>
        public static bool operator !=(TimePeriod tp1, TimePeriod tp2)
        {
            return !(tp1 == tp2);
        }
    }
}
