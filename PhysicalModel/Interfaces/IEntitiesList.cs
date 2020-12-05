using Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface IEntitiesList {

        public delegate void LocationsChangedHandler(LinkedList<EntityLocation> locations);
        public void SetLocationsChangedHandler(LocationsChangedHandler handler);

        public void SetClockHandler(IClockGenerator generator);

        public void AddEntity(EntityStartingData data);

    }
}
