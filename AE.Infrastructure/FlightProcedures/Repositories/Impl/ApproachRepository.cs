using AE.FlightProcedures.Domain.Approaches;
using AE.FlightProcedures.Domain.Approaches.Factories;
using AE.FlightProcedures.Domain.Approaches.Repositories;
using AE.FlightProcedures.Domain.Segments;
using AE.FlightProcedures.Domain.Segments.Repositories;
using AE.Infrastructure.FlightProcedures.Repositories.Impl.Dtos;
using NHibernate;
using System;
using System.Collections.Generic;

namespace AE.Infrastructure.FlightProcedures.Repositories.Impl
{
    internal class ApproachRepository : IApproachRepository
    {
        private readonly ISessionFactory sessionFactory;
        private readonly IApproachFactory approachFactory;
        private readonly Func<ISessionFactory, IEsaRepository> esaRepositoryFactory;

        public ApproachRepository(
            ISessionFactory sessionFactory, 
            IApproachFactory approachFactory,
            Func<ISessionFactory, IEsaRepository> esaRepositoryFactory)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");
            if (approachFactory == null)
                throw new ArgumentNullException("approachFactory");
            if (esaRepositoryFactory == null)
                throw new ArgumentNullException("esaRepositoryFactory");

            this.sessionFactory = sessionFactory;
            this.approachFactory = approachFactory;
            this.esaRepositoryFactory = esaRepositoryFactory;
        }

        public void Save(Approach approach)
        {
            if (approach == null)
                throw new ArgumentNullException("approach");

            using(ISession session = this.sessionFactory.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    NHApproachDto dto = new NHApproachDto();
                    dto.Id = approach.Id;
                    dto.Name = approach.Name.Value;
                    dto.Criteria = approach.Criteria.Value;
                    ApproachEsa esa = approach.Esa;
                    dto.EsaId = esa != null ? (Guid?)esa.Id : null;                    

                    session.SaveOrUpdate(dto);

                    transaction.Commit();
                }
            }
        }

        public IList<Approach> GetApproaches()
        {
            IList<NHApproachDto> approaches = new List<NHApproachDto>();

            using(ISession session = this.sessionFactory.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    approaches = session.QueryOver<NHApproachDto>().List();

                    transaction.Commit();
                }
            }

            IList<Approach> results = new List<Approach>();
            foreach (NHApproachDto approach in approaches)
            {
                Approach model = this.approachFactory.CreateApproach(approach.Id, approach.Name, approach.Criteria);
                if(approach.EsaId.HasValue)
                {
                    IEsaRepository repository = this.esaRepositoryFactory.Invoke(this.sessionFactory);
                    Esa esa = repository.GetEsa(approach.EsaId.Value);
                    if(esa != null) model.AddEsa(esa);
                }
                results.Add(model);
            }

            return results;
        }

        public Approach GetApproach(Guid id)
        {
            NHApproachDto dto = null;

            using(ISession session = sessionFactory.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    dto = session.QueryOver<NHApproachDto>().Where(x => x.Id == id).SingleOrDefault();
                    transaction.Commit();
                }
            }

            if (dto == null)
                return null;

            return this.approachFactory.CreateApproach(dto.Id, dto.Name, dto.Criteria);
        }
    }
}