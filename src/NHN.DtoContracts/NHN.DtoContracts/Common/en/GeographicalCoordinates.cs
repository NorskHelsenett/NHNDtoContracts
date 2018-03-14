using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Geografiske koordinater
    /// </summary>
    [DataContract(Namespace = Namespaces.CommonOldV1)]
    [Serializable]
    public struct LatitudeLongitude
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public LatitudeLongitude(double latitude, double longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }

        [DataMember(Name="Latitude")]
        private double _latitude;
        /// <summary>
        /// Breddegrad
        /// </summary>
        public double Latitude => _latitude;

        [DataMember(Name = "Longitude")]
        private double _longitude;
        /// <summary>
        /// Lengdegrad
        /// </summary>
        public double Longitude => _longitude;

        /// <summary>
        /// Hvorvidt de satte koordinatene gir mening
        /// </summary>
        public bool IsValid => Latitude < 90.0 && Latitude > -90.0 && Longitude < 180.0 && Longitude > -180.0;

        /// <summary>
        /// Stringrepresentasjon: Lat,Long
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Latitude.ToString(CultureInfo.InvariantCulture)},{Longitude.ToString(CultureInfo.InvariantCulture)}";
        }

        /// <summary>
        /// Parser lat,long. F.eks 0.123123,0.41451. If null/empty, return null. If not null but invalid, will throw exception.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static LatitudeLongitude? ParseFromText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var components = text.Split(',');
            if (components.Length != 2) throw new InvalidOperationException("Invalid Coordinate.");

            double lat, lon;

            if (!double.TryParse(components[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lat))
                throw new InvalidOperationException("Invalid coordiante");

            if (!double.TryParse(components[1], NumberStyles.Float, CultureInfo.InvariantCulture, out lon))
                throw new InvalidOperationException("Invalid coordiante");

            return new LatitudeLongitude(lat, lon);
        }
    }
}
