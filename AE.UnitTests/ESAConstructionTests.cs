using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AE.FlightProcedures.Domain.Construction.Segments.Airspaces.Impl;
using AE.FlightProcedures.Domain.Construction.Segments.Airspaces;
using AE.FlightProcedures.Domain.Calculations.Common.Impl;
using GeoAPI.Geometries;
using NetTopologySuite.IO;

namespace AE.UnitTests
{
    [TestClass]
    public class ESAConstructionTests
    {
        [TestMethod]
        public void ConstructEsa()
        {
            IEsaConstructBuilder builder = new EsaConstructBuilder(
                new ArcDerivation(),
                new LocationDerivation());

            IGeometry construct = builder.BuildEsa(100000, 35.000, 94.000);

            var value = construct.AsText();

            Assert.IsNotNull(value);
        }
    }
}
