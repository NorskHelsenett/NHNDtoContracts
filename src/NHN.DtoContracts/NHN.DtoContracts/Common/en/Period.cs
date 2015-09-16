using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// En tidsperiode.
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglish)]
    [Serializable]
    public class Period
    {
        /// <summary>
        /// From
        /// </summary>
        [DataMember]
        public DateTime From { get; set; }

        /// <summary>
        /// To. Can be null if no expire time
        /// </summary>
        [DataMember]
        public DateTime? To { get; set; }

        public Period()
        {
            From = DateTime.Now;
            To = null;
        }

        public Period(DateTime from, DateTime? to = null)
        {
            From = from;
            To = to;
        }

        public Period(int fromYear, int fromMonth, int fromDay, int toYear = 0, int toMonth = 0, int toDay = 0)
        {
            From = new DateTime(fromYear, fromMonth, fromDay);
            if (toYear > 0)
                To = new DateTime(toYear, toMonth, toDay);
        }

        /// <summary>
        /// Hvorvidt nåtid er mellom From og To
        /// </summary>
        public bool IsActiveNow
        {
            get { return Overlaps(DateTime.Now); }
        }

        public bool Sane
        {
            get
            {
                if (From > new DateTime(9000, 1, 1))
                    return false;
                if (To != null)
                    return To.Value > From;
                return true;
            }
        }

        public bool Overlaps(Period other)
        {
            if (object.ReferenceEquals(this, other))
                throw new InvalidOperationException("Period overlaps self, should not be tested..");

            if (this.From == other.From || this.To == other.To)
                return true;

            if (this.From > other.From)
                return other.To == null || other.To > this.From;
            else
                return this.To == null || other.From < this.To.Value;
        }

        public bool Overlaps(DateTime pointInTime)
        {
            if (this.From > pointInTime)
                return false;
            return (this.To == null || this.To.Value > pointInTime);
        }

        public override bool Equals(object obj)
        {
            var po = obj as Period;
            if (po == null)
                return false;
            return To == po.To && From == po.From;
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() + (To ?? default(DateTime)).GetHashCode();
        }

        public override string ToString()
        {
            return $"Period: {From.ToShortDateString()}, To: {(To == null ? " (null)" : To.Value.ToShortDateString())}";
        }
    }
}