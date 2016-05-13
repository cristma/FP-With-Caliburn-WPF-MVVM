using AE.FlightProcedures.AppServices.Approaches.Builders.Impl;
using AE.FlightProcedures.AppServices.Approaches.Impl.Dtos;
using AE.FlightProcedures.AppServices.Segments.Impl.Dtos;
using AE.FlightProcedures.Domain.Approaches;
using AE.FlightProcedures.Domain.Approaches.Repositories;
using AE.FlightProcedures.Domain.Evaluation.Deviations.Factories;
using AE.FlightProcedures.Domain.Evaluation.Observers;
using AE.FlightProcedures.Domain.Segments;
using AE.FlightProcedures.Domain.Segments.Factories;
using AE.FlightProcedures.Domain.Segments.Repositories;
using AE.Infrastructure.Providers;
using GeoAPI.Geometries;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace AE.FlightProcedures.AppServices.Approaches.Impl
{
    public class ApproachService : IApproachService
    {
        private readonly IApproachRepository approachRepository;
        private readonly IEsaRepository esaRepository;
        private readonly IDeviationObserver deviationObserver;
        private readonly IDeviationFactory deviationFactory;
        private readonly IEsaDtoBuilder builder;
        private readonly IEsaFactory factory;

        internal ApproachService(
            Func<ISessionFactory, IApproachRepository> approachRepositoryFactory,
            Func<ISessionFactory, IEsaRepository> esaRepositoryFactory, 
            ISessionFactoryProvider sessionFactoryProvider, 
            IDeviationObserver deviationObserver, 
            IDeviationFactory deviationFactory,
            IEsaDtoBuilder builder,
            IEsaFactory factory)
        {
            if (approachRepositoryFactory == null)
                throw new ArgumentNullException("approachRepositoryFactory");
            if (esaRepositoryFactory == null)
                throw new ArgumentNullException("esaRepositoryFactory");
            if (sessionFactoryProvider == null)
                throw new ArgumentNullException("sessionFactoryProvider");
            if (deviationObserver == null)
                throw new ArgumentNullException("deviationObserver");
            if (deviationFactory == null)
                throw new ArgumentNullException("deviationFactory");
            if (builder == null)
                throw new ArgumentNullException("builder");
            if (factory == null)
                throw new ArgumentNullException("factory");

            ISessionFactory sessionFactory = sessionFactoryProvider.ForWorkspace();
            this.approachRepository = approachRepositoryFactory.Invoke(sessionFactory);
            this.esaRepository = esaRepositoryFactory.Invoke(sessionFactory);
            this.deviationFactory = deviationFactory;
            this.deviationObserver = deviationObserver;
            this.builder = builder;
            this.factory = factory;
        }

        public bool HasEsa(Guid id)
        {
            Esa esa = this.GetSingleEsa(id);
            return esa != null;
        }

        public void CreateApproach(ApproachDetailsDto dto)
        {
            Contract.Assert(dto != null, "Approach details DTO may not be null to create an approach.");

            Name name = new Name(dto.Name);
            Criteria criteria = new Criteria(dto.Criteria);
            Approach approach = new Approach(dto.Id, name, criteria);

            this.CreateApproach(approach);
        }

        public void CreateEsa(EsaSummaryDto dto)
        {
            Esa model = this.factory.CreateEsa(dto.Id, dto.Altitude, dto.Radius, dto.CenterLatitude, dto.CenterLongitude);
            Approach approach = this.GetSingleApproach(model.ApproachId);
            approach.AddEsa(model);
            this.CreateApproach(approach);
            this.CreateEsa(model);
        }

        public EsaSummaryDto GetEsa(Guid id)
        {
            Esa esa = this.GetSingleEsa(id);
            EsaSummaryDto dto = builder.ToDto(esa);

            return dto;
        }

        public IList<Tuple<double, double>> GetConstruct(Guid id)
        {
            Esa esa = this.GetSingleEsa(id);
            Coordinate[] coords = esa.Construct.Value.Coordinates;
            IList<Tuple<double, double>> points = new List<Tuple<double, double>>();

            foreach (Coordinate coord in coords)
            {
                points.Add(new Tuple<double, double>(coord.Y, coord.X));
            }

            return points;
        }

        public IReadOnlyList<ApproachSummaryDto> GetApproaches()
        {
            IList<Approach> approaches = this.GetAllApproaches();
            IList<ApproachSummaryDto> summaries = new List<ApproachSummaryDto>();

            foreach (Approach approach in approaches)
            {
                ApproachSummaryDto dto = new ApproachSummaryDto(
                    approach.Id,
                    approach.Name.Value, 
                    approach.Criteria.Value);
                summaries.Add(dto);
            }

            return (summaries as List<ApproachSummaryDto>).AsReadOnly();
        }

        public ApproachDetailsDto GetApproach(Guid id)
        {
            Approach approach = this.GetSingleApproach(id);
            return new ApproachDetailsDto(
                approach.Id,
                approach.Name.Value,
                approach.Criteria.Value);
        }

        private void CreateApproach(Approach approach)
        {
            this.approachRepository.Save(approach);
        }

        private void CreateEsa(Esa esa)
        {
            this.esaRepository.SaveEsa(esa);
        }

        private IList<Approach> GetAllApproaches()
        {
            IList<Approach> approaches = this.approachRepository.GetApproaches();
            return approaches;
        }

        private Approach GetSingleApproach(Guid id)
        {
            Approach approach = this.approachRepository.GetApproach(id);
            approach.Evaluate(this.deviationObserver, this.deviationFactory);
            return approach;
        }

        private Esa GetSingleEsa(Guid id)
        {
            Esa esa = this.esaRepository.GetEsa(id);
            return esa;
        }
    }
}