using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;

namespace PhysicalModel.Interfaces {
    interface IArea {
        public double XAr { get; set; }

        public double YAr { get; set; }

        public void SetXY(double x, double y);

        public EntityLocation GetLocation();

        public bool AddEntity(IEntity entity);

        public bool GiveEntity(IArea area, IEntity entity);

        public delegate void LocationsChangedHandler(EntityLocation source, LinkedList<EntityLocation> locations);
        public void SetLocationsChangedHandler(LocationsChangedHandler handler);

        public void GetClockHandler(IClockGenerator generator);
    }
}
