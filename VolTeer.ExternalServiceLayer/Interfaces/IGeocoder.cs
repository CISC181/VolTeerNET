using VolTeer.DomainModels;
using VolTeer.DomainModels.Service;

namespace VolTeer.ExternalServiceLayer
{
    public interface IGeocoder
    {
        /// <summary>
        /// Attemps to retrieve the lat/lon associated with the given address.
        /// </summary>
        /// <param name="address">The address to locate.</param>
        /// <returns>A <see cref="Coordinate" /> object, or null if the address could not be located.</returns>
        string GetLatLongFromAddress(GoogleAddress address);
    }
}
