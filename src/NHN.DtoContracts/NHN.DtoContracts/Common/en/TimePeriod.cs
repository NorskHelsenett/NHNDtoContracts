using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// En tidsperiode uten informasjon om dato.
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglishOld)]
    [Serializable]
    public struct TimePeriod : IComparable<TimePeriod>
    {
        public static TimePeriod FromHours(double from, double to)
        {
            return new TimePeriod(TimeSpan.FromHours(from), TimeSpan.FromHours(to));
        }

        public static TimePeriod FromMinutes(int from, int to)
        {
            return new TimePeriod(TimeSpan.FromMinutes(from), TimeSpan.FromMinutes(to));
        }

        public TimePeriod(TimeSpan from, TimeSpan to)
        {
            if (to < from)
                throw new ArgumentException($"To ({to}) can not be less than From ({from})");

            From = from;
            To = to;
        }

        public TimeSpan Length => To - From;

        public TimeSpan From { get; private set; }

        public TimeSpan To { get; private set; }

        public int CompareTo(TimePeriod other)
        {
            var result = From.CompareTo(other.From);
            return result != 0 ? result : To.CompareTo(other.To);
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            return ((TimePeriod)obj) == this;
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() + To.GetHashCode();
        }

        public static bool operator ==(TimePeriod tp1, TimePeriod tp2)
        {
            return tp1.From == tp2.From && tp1.To == tp2.To;
        }

        public static bool operator !=(TimePeriod tp1, TimePeriod tp2)
        {
            return !(tp1 == tp2);
        }
    }
}
