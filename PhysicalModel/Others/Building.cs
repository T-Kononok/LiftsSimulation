using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Entities;

namespace PhysicalModel {
    public class Building : IBuilding {
        public double Interval { get; } = 3.0;

        private readonly List<IFloor> _floors = new List<IFloor>();
        private IShafts _shafts;

        public Building() { }

        public bool SetFloors(int quantityFloors,
            IFloor.Factory floorFactory, ILiftsHall.Factory hallFactory) {

            _floors.Add(floorFactory(0, 7.0, 0.0, 0.0, hallFactory));
            for (var i = 1; i < quantityFloors; i++) {
                _floors.Add(floorFactory(i, 3.5, 0.0, 3.5 + i * 3.5, hallFactory));
            }
            return true;
        }

        public bool SetLifts(List<ILift> lifts, IShafts.Factory shaftsFactory) {
            if (_floors == null)
                return false;
            _shafts = shaftsFactory(lifts, 0.0, 0.0, Interval, _floors.Count * 3.5 + 3.5);
            return true;
        }

        public bool SetManager(IManagerLifts manager) {
            if (_shafts == null)
                return false;
            foreach (ILift lift in _shafts) {
                manager.AddLift(lift);
            }
            foreach (IFloor floor in _floors) {
                manager.AddHall(floor.Hall);
                floor.Hall.LiftCalling += manager.LiftCallingHandler;
            }
            return true;
        }

        public bool SetGenerator(IClockGenerator generator) {
            if (_shafts == null)
                return false;
            generator.Clock += _shafts.ClockHandler;
            foreach (ILift lift in _shafts) {
                generator.Clock += lift.ClockHandler;
            }
            foreach (IFloor floor in _floors) {
                generator.Clock += floor.ClockHandler;
                generator.Clock += floor.Hall.ClockHandler;
            }
            return true;
        }

        public bool AddPassenger(IPassenger passenger) {
            return _floors[passenger.StartingFloor].AddPassenger(passenger);
        }

        public bool TurnOffAlarm() {
            throw new NotImplementedException();
        }

        public bool TurnOnAlarm() {
            throw new NotImplementedException();
        }

        public bool SetPositionsChangedHandlers(Action<Position, List<Position>> handler) {
            if (_shafts == null)
                return false;
            _shafts.PositionsChanged += handler;
            foreach (ILift lift in _shafts)
                lift.PositionsChanged += handler;
            foreach (IFloor floor in _floors)
                floor.PositionsChanged += handler;
            return true;
        }
    }
}
