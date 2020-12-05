using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhysicalModel.Interfaces;
using Presentation.Entities;

namespace PhysicalModel {
    class Shafts : IShafts {

        private readonly List<Lift> _lifts = new List<Lift>();

        public double XAr { get; set; }
        public double YAr { get; set; }

        public double Length { get; } = 0;

        public Shafts(int quantity, IClockGenerator generator) {
            for (var i = 0; i < quantity; i++) {
                var lift = new Lift();
                lift.SetXY(i * (ILift.Length + IShafts.Interval),0);
                lift.Source = this;
                _lifts.Add(lift);
            }
            Length = quantity * (ILift.Length + IShafts.Interval) - IShafts.Interval;
            GetClockHandler(generator);
            foreach (Lift lift in _lifts)
                lift.GetClockHandler(generator);
        }

        public void SetXY(double x, double y) {
            XAr = x;
            YAr = y;
        }

        public bool AddEntity(IEntity entity) {
            return false;
        }

        public bool GiveEntity(IArea area, IEntity entity) {
            return false;
        }

        public void SetManager(LiftsManager manager) {
            foreach (Lift lift in _lifts)
                lift.SetManager(manager);
        }

        event IArea.LocationsChangedHandler LocationsChanged;
        public void SetLocationsChangedHandler(IArea.LocationsChangedHandler handler) {
            foreach(Lift lift in _lifts )
                lift.SetLocationsChangedHandler(handler);
            LocationsChanged += handler;
        }

        private void ClockHandler() {
            var locations = new LinkedList<EntityLocation>();
            Parallel.ForEach(_lifts, RecalculateAllLocations);
            LocationsChanged(GetLocation(), locations);

            void RecalculateAllLocations(IEntity entity) {
                entity.RecalculateLocation();
                locations.AddFirst(entity.GetLocation());
            }
        }

        public void GetClockHandler(IClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }

        public EntityLocation GetLocation() {
            return new EntityLocation(EntityType.Unknown, XAr, YAr);
        }
    }

}
