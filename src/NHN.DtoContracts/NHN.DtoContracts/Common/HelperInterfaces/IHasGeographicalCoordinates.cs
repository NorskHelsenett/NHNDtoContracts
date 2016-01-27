using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Common.HelperInterfaces
{
    /// <summary>
    /// Hjelpegrensesnitt: Har geografiske koordinater
    /// </summary>
    public interface IHasGeographicalCoordinates
    {
        /// <summary>
        /// Geografiske koordianter
        /// </summary>
        LatitudeLongitude? GeographicalCoordinates { get; set; }
    }
}
