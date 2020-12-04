using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Presentation.Entities;

namespace PhysicalModel {
    class EntitiesList {

        private AreasList _areasList = new AreasList();

        private LinkedList<Entity> _entities = new LinkedList<Entity>();
        private LinkedList<EntityLocation> _locations;

        public delegate void LocationsChangedHandler(LinkedList<EntityLocation> locations);
        event LocationsChangedHandler LocationsChanged;

        public void SetLocationsChangedHandler(LocationsChangedHandler handler) {
            LocationsChanged += handler;
        }

        private void ClockHandler() {
            _locations = new LinkedList<EntityLocation>();
            Parallel.ForEach(_entities, RecalculateLocation);
            LocationsChanged(_locations);
        }

        private void WaitHandler(Human human) {
            _areasList.AddHuman(human);
        }

        void RecalculateLocation(Entity entity) {
            if (entity.RecalculateLocation())
                _locations.AddFirst(entity.GetLocation());
            else
                _entities.Remove(entity);
        }

        public EntitiesList(ClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }

        public void AddEntity(EntityStartingData data) {
            switch (data.Type) {
                case EntityType.Human:
                    _entities.AddFirst(new Human((HumanStartingData)data, WaitHandler)) ;
                    break;
                case EntityType.Lift:
                    break;
                default:
                    System.Console.WriteLine("Попытка добавить неизвестного!");
                    break;
            }

        }
    }
}
