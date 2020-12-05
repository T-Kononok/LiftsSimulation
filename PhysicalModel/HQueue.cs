using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhysicalModel.Interfaces;
using Presentation.Entities;

namespace PhysicalModel {
    class HQueue : IHQueue {

        private LiftsManager _manager;

        private int number;

        private readonly Queue<IEntity> _entities = new Queue<IEntity>();

        public double XAr { get; set; }
        public double YAr { get; set; }

        public HQueue() { }

        public void SetXY(double x, double y) {
            XAr = x;
            YAr = y;
        }

        public EntityLocation GetLocation() {
            return new EntityLocation(EntityType.Unknown, XAr, YAr);
        }
     
        public bool AddEntity(IEntity entity) {
            if (_entities.Count == IHQueue.MaxCount)
                return false;
            IHuman human = (IHuman)entity;
            _manager._map[number].Enqueue(human.TargetFloor);
            entity.X = _entities.Count * IEntity.Diameter * 1.5;
            _entities.Enqueue(entity);
            entity.Source = this;
            return true;
        }

 
        public bool GiveEntity(IArea area, IEntity entity) {
            if (!area.AddEntity(_entities.Peek()))
                return false;
            _entities.Dequeue();
            foreach (IEntity e in _entities)
                e.X -= IEntity.Diameter * 1.5;
            return true;
        }

        public void SetManager(LiftsManager manager) {
            _manager = manager;
        }

        event IArea.LocationsChangedHandler LocationsChanged;
        public void SetLocationsChangedHandler(IArea.LocationsChangedHandler handler) {
            LocationsChanged += handler;
        }

        private void ClockHandler() {
            var locations = new LinkedList<EntityLocation>();
            Parallel.ForEach(_entities, GetAllLocations);
            LocationsChanged(GetLocation(), locations);

            void GetAllLocations(IEntity entity) {
                locations.AddFirst(entity.GetLocation());
            }
        }

        public void GetClockHandler(IClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }


    }
}
