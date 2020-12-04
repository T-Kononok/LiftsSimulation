using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Presentation.Entities;

namespace PhysicalModel {
    class EntitiesList {

        private List<Entity> _entities = new List<Entity>();
        private List<EntityLocation> _locations;

        public delegate void LocationsChangedHandler(List<EntityLocation> locations);
        event LocationsChangedHandler LocationsChanged;

        public void SetLocationsChangedHandler(LocationsChangedHandler handler) {
            LocationsChanged += handler;
        }

        private void ClockHandler() {
            _locations = new List<EntityLocation>();
            Parallel.ForEach(_entities, RecalculateLocation);
            LocationsChanged(_locations);
        }

        void RecalculateLocation(Entity entity) {
            entity.RecalculateLocation();
            _locations.Add(entity.GetLocation());
        }

        public EntitiesList(ClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }

        public void AddEntity(Entity data) {
            //
        }
    }
}
