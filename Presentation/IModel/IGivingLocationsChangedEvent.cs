using Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Presentation.IModel {
    interface IGivingLocationsChangedEvent {

        public delegate void LocationsChangedHandler(List<EntityLocation> locations);
        event LocationsChangedHandler LocationsChanged;
        public void SetLocationsChangedHandler(LocationsChangedHandler handler);
    }
}
