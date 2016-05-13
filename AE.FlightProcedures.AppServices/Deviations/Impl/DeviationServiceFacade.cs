using AE.FlightProcedures.AppServices.Deviations.Builders;
using AE.FlightProcedures.AppServices.Deviations.Impl.Dtos;
using AE.FlightProcedures.Domain.Evaluation.Deviations;
using System;
using System.Collections.Generic;

namespace AE.FlightProcedures.AppServices.Deviations.Impl
{
    public class DeviationServiceFacade : IDeviationServiceFacade
    {
        private readonly IDeviationService deviationService;
        private readonly IDeviationDtoBuilder dtoBuilder;

        internal DeviationServiceFacade(
            IDeviationService deviationService, 
            IDeviationDtoBuilder dtoBuilder)
        {
            if (deviationService == null)
                throw new ArgumentNullException("deviationService");
            if (dtoBuilder == null)
                throw new ArgumentNullException("dtoBuilder");

            this.deviationService = deviationService;
            this.dtoBuilder = dtoBuilder;
        }

        public IList<DeviationSummaryDto> GetDeviations()
        {
            IList<Deviation> deviations = this.deviationService.GetDeviations();
            IList<DeviationSummaryDto> dtos = new List<DeviationSummaryDto>();

            foreach(Deviation deviation in deviations)
            {
                DeviationSummaryDto dto = this.dtoBuilder.ToDto(deviation);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}