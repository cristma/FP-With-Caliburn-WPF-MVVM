using GeoAPI.Geometries;

namespace AE.FlightProcedures.Domain.Construction.Segments.Airspaces
{
    internal interface IEsaConstructBuilder
    {
        IGeometry BuildEsa(double radius, double latitude, double longitude);
    }
}