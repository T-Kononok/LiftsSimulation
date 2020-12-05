using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhysicalModel.Interfaces;
using Presentation.Entities;

namespace PhysicalModel {
    class Floor<Q> : IFloorQ<Q>
        where Q : IHQueue, new() {

        public double XAr { get; set; }
        public double YAr { get; set; }

        public readonly Q _queue = new Q();

        private readonly LinkedList<IEntity> _entities = new LinkedList<IEntity>();

        public Floor(double x, double y, IClockGenerator generator) {
            _queue.GetClockHandler(generator);
            GetClockHandler(generator);
            _queue.SetXY(x, y);
            SetXY(x, y);
        }

        public void SetXY(double x, double y) {
            XAr = x;
            YAr = y;
        }

        public EntityLocation GetLocation() {
            return new EntityLocation(EntityType.Unknown, XAr, YAr);
        }

        public bool AddEntity(IEntity entity) {
            switch (entity.Type) {
                case EntityType.Human:
                    _entities.AddFirst(entity);
                    entity.Source = this;
                    entity.X = IFloor.Length * 0.9;
                    entity.Y = 2 * IEntity.Diameter;
                    return true;
                case EntityType.Lift:
                    System.Console.WriteLine("Попытка добавить лифт в коридор!");
                    return false;
                default:
                    System.Console.WriteLine("Попытка добавить неизвестного!");
                    return false;
            }
        }

        public bool GiveEntity(IArea area, IEntity entity) {
            _entities.Remove(entity);
            return area.AddEntity(entity);
        }

        public void SetManager(LiftsManager manager) {
            _queue.SetManager(manager);
        }

        event IArea.LocationsChangedHandler LocationsChanged;
        public void SetLocationsChangedHandler(IArea.LocationsChangedHandler handler) {
            _queue.SetLocationsChangedHandler(handler);
            LocationsChanged += handler;
        }

        private void ClockHandler() {
            var locations = new LinkedList<EntityLocation>();
            Parallel.ForEach(_entities, RecalculateAllLocations);
            LocationsChanged(GetLocation(), locations);

            void RecalculateAllLocations(IEntity entity) {
                if (entity.RecalculateLocation()) {
                    locations.AddFirst(entity.GetLocation());

                    if (entity.X < IHQueue.Length)
                        if (!GiveEntity(_queue, entity))
                            entity.X += 0.1*IFloorQ<Q>.Length;
                } else
                    _entities.Remove(entity);
            }
        }

        public void GetClockHandler(IClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }
    }
}
