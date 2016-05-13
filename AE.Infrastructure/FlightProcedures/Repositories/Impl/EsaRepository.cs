using AE.FlightProcedures.Domain.Segments;
using AE.FlightProcedures.Domain.Segments.Factories;
using AE.FlightProcedures.Domain.Segments.Repositories;
using AE.Infrastructure.FlightProcedures.Repositories.Impl.Dtos;
using NHibernate;
using System;

namespace AE.Infrastructure.FlightProcedures.Repositories.Impl
{
    internal class EsaRepository : IEsaRepository
    {
        private readonly ISessionFactory sessionFactory;
        private readonly IEsaFactory esaFactory;

        public EsaRepository(
            ISessionFactory sessionFactory, 
            IEsaFactory esaFactory)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");
            if (esaFactory == null)
                throw new ArgumentNullException("esaFactory");

            this.sessionFactory = sessionFactory;
            this.esaFactory = esaFactory;
        }

        public Esa GetEsa(Guid id)
        {
            NHEsaDto dto = null;

            using (ISession session = this.sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    dto = session.QueryOver<NHEsaDto>().Where(x => x.Id == id).SingleOrDefault();

                    transaction.Commit();
                }
            }

            if (dto == null)
                return null;

            Esa model = this.esaFactory.CreateEsa(dto.Id, dto.Altitude, dto.Radius, dto.CenterLatitude, dto.CenterLongitude);

            return model;
        }

        public void SaveEsa(Esa esa)
        {
            if (esa == null)
                throw new ArgumentNullException("esa");

            NHEsaDto dto = new NHEsaDto();
            dto.Altitude = esa.Altitude.Value;
            dto.CenterLatitude = esa.Location.Latitude.Value;
            dto.CenterLongitude = esa.Location.Longitude.Value;
            dto.Id = esa.Id;
            dto.Radius = esa.Radius.Value;
            dto.Wkt = esa.Construct.Value.AsText();
            
            using(ISession session = this.sessionFactory.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(dto);
                    transaction.Commit();
                }
            }
        }
    }
}