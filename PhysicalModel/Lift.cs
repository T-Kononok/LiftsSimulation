using Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using PhysicalModel.Interfaces;
using System.Threading.Tasks;

namespace PhysicalModel {
    class Lift : Entity, ILift {

        private LiftsManager _liftsManager;
        private Queue<int> _targets = new Queue<int>();

        List<IEntity> _entities = new List<IEntity>();

        public int GetCount() { return _entities.Count; }

        private double _speed = 1.8;

        private bool _isFull = false;

        public double XAr { get; set; }
        public double YAr { get; set; }

        public Lift() 
            : base(EntityType.Lift,0,0) {
        }

        public override EntityLocation GetLocation() {
            return new EntityLocation(EntityType.Lift, Source.XAr + X, Source.YAr + Y);
        }

        public override bool RecalculateLocation() {
            if (_targets.Count == 0) {
                for (var i = 0; i < IFloor.Quantity; i++) {
                    if (GetFloor() + i < IFloor.Quantity)
                        if (_liftsManager._map[GetFloor() + i].Count > 0) {
                            _targets.Enqueue(_liftsManager._map[GetFloor() + i].Dequeue());
                            break;
                        }
                    if (GetFloor() - i > 0)
                        if (_liftsManager._map[GetFloor() - i].Count > 0) {
                            _targets.Enqueue(_liftsManager._map[GetFloor() - i].Dequeue());
                            break;
                        }
                }
            }
            if (_targets.Peek() == GetFloor()) {
                if (_isFull) {
                    var entitites = _entities[0];
                    GiveEntity(_liftsManager._floors[GetFloor()], entitites);
                    _entities.Remove(entitites);
                } else {
                    _liftsManager._floors[GetFloor()]._queue.GiveEntity(this,null);
                }
            }
            return true;
        }

        public void SetXY(double x, double y) {
            X = x;
            Y = y;
            XAr = x;
            YAr = y;
        }

        public bool AddEntity(IEntity entity) {
            if (_entities.Count == ILift.Capacity)
                return false;
            entity.X = _entities.Count * IEntity.Diameter * 1.5;
            _entities.Add(entity);
            entity.Source = this;
            return true;
        }

        public bool GiveEntity(IArea area, IEntity entity) {
            if (entity.Type == EntityType.Human) {
                Human human = (Human)entity;
                human.IsArrival = true;
                entity = human;
            }
            if (!area.AddEntity(entity))
                return false;
            _entities.Remove(entity);
            for (var i = 0; i < _entities.Count; i++)
                _entities[i].X = i * IEntity.Diameter * 1.5;
            return true;
        }

        public void SetManager(LiftsManager manager) {
            _liftsManager = manager;
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

        private int GetFloor() {
            return (int)(Y / IFloor.Quantity) + 1;
        }
    }
}
