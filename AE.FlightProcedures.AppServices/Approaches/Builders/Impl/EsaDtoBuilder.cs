using AE.FlightProcedures.AppServices.Segments.Impl.Dtos;
using AE.FlightProcedures.Domain.Segments;

namespace AE.FlightProcedures.AppServices.Approaches.Builders.Impl
{
    internal class EsaDtoBuilder : IEsaDtoBuilder
    {
        public EsaSummaryDto ToDto(Esa model)
        {
            return new EsaSummaryDto(model.Id, model.Altitude.Value, model.Radius.Value, model.Location.Latitude.Value, model.Location.Longitude.Value);
        }
    }
}
