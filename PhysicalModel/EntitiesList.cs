using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Presentation.Entities;
using PhysicalModel.Interfaces;

namespace PhysicalModel {
    class EntitiesList : IEntitiesList {

        private IAreaList _areasList;

        private LinkedList<Entity> _entities = new LinkedList<Entity>();
        

        event IEntitiesList.LocationsChangedHandler LocationsChanged;
        public void SetLocationsChangedHandler(IEntitiesList.LocationsChangedHandler handler) {
            LocationsChanged += handler;
        }

        private void ClockHandler() {
            var locations = new LinkedList<EntityLocation>();
            Parallel.ForEach(_entities, RecalculateAllLocations);
            LocationsChanged(locations);

            void RecalculateAllLocations(Entity entity) {
                if (entity.RecalculateLocation())
                    locations.AddFirst(entity.GetLocation());
                else
                    _entities.Remove(entity);
            }
        }

        public void SetClockHandler(IClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }

        public EntitiesList(IClockGenerator generator, IAreaList areaList) {
            SetClockHandler(generator);
            _areasList = areaList;
        }

        public void AddEntity(EntityStartingData data) {
            switch (data.Type) {
                case EntityType.Human:
                    _entities.AddFirst(new Human((HumanStartingData)data, _areasList.AddHuman)) ;
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
