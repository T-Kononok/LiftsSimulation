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

            _floors.Add(floorFactory(0, 7.0, _shafts.Size.Length + 20.0, 0.0, hallFactory));
            for (var i = 1; i < quantityFloors; i++) {
                _floors.Add(floorFactory(i, 3.5, _shafts.Size.Length + 20.0,
                    3.5 + i * 3.5, hallFactory));
            }
            return true;
        }

        public bool SetLifts(int quantityFloors, List<ILift> lifts,
            IShafts.Factory shaftsFactory) {
            _shafts = shaftsFactory(lifts, 0.0, 0.0, Interval, quantityFloors * 3.5 + 3.5);
            return true;
        }

        public bool SetManager(IManagerLifts manager) {
            foreach (ILift lift in _shafts) {
                manager.AddLift(lift);
            }
            foreach (IFloor floor in _floors) {
                manager.AddHall(floor.Hall);
                floor.Hall.LiftCalling += manager.LiftCallingHandler;
            }
            manager.BuildMap();
            return true;
        }

        public bool SetGenerator(IClockGenerator generator, IManagerLifts manager) {
            generator.Clock += _shafts.ClockHandler;
            generator.Clock += manager.HandleClock;
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
            return _floors[passenger.StartingFloor-1].AddPassenger(passenger);
        }

        public bool TurnOffAlarm() {
            throw new NotImplementedException();
        }

        public bool TurnOnAlarm() {
            throw new NotImplementedException();
        }

        public bool SetPositionsChangedHandlers(Action<Position, List<Position>> handler) {
            _shafts.PositionsChanged += handler;
            foreach (ILift lift in _shafts)
                lift.PositionsChanged += handler;
            foreach (IFloor floor in _floors) {
                floor.PositionsChanged += handler;
                floor.Hall.PositionsChanged += handler;
            }
            return true;
        }
    }
}
