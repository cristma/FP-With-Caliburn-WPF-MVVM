using AE.FlightProcedures.Domain.Approaches;
using AE.FlightProcedures.Domain.BoilerPlate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments
{
    internal class Esa : Entity
    {
        public Esa(
            Guid id, 
            Altitude altitude, 
            Radius radius, 
            Location location, 
            Construct construct, 
            Guid approachId)
            : base(id)
        {
            if (altitude == null)
                throw new ArgumentNullException("altitude");
            if (radius == null)
                throw new ArgumentNullException("radius");
            if (location == null)
                throw new ArgumentNullException("location");
            if (construct == null)
                throw new ArgumentNullException("construct");

            this.Altitude = altitude;
            this.Radius = radius;
            this.Location = location;
            this.Construct = construct;
            this.ApproachId = approachId;
        }

        public Altitude Altitude { get; private set; }
        public Radius Radius { get; private set; }
        public Location Location { get; private set; }
        public Construct Construct { get; private set; }
        public Guid ApproachId { get; private set; }
    }
}
