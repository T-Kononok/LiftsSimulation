using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using PhysicalModel.Others.Interfaces;

namespace PhysicalModel.Others {
    class Building : IBuilding {
        public Size Size { get; }
        public double Interval { get; } = 3.0;

        private readonly List<IFloor> _floors = new List<IFloor>();
        private readonly IShafts _shafts;

        public Building(int quantityFloors, List<ILift> lifts,
            IClockGenerator generator, IManagerLifts manager, IFloor.Factory floorFactory, 
            ILiftsHall.Factory hallFactory, IShafts.Factory shaftsFactory) {

            _shafts = shaftsFactory(lifts, 0.0, 0.0, Interval, quantityFloors*3.5+3.5);

            generator.Clock += _shafts.ClockHandler;
            foreach (ILift lift in _shafts) {
                generator.Clock += lift.ClockHandler;
                manager.AddLift(lift);
            }

            _floors.Add(floorFactory(0, 7.0, 0.0, 0.0, hallFactory));
            for (var i = 1; i < quantityFloors; i++) {
                _floors.Add(floorFactory(i, 3.5, 0.0, 3.5+i*3.5, hallFactory));
            }

            foreach (IFloor floor in _floors) {
                generator.Clock += floor.ClockHandler;
                generator.Clock += floor.Hall.ClockHandler;
                manager.AddHall(floor.Hall);
                floor.Hall.LiftCalling += manager.LiftCallingHandler;
            }
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

        public void SetPositionsChangedHandlers(Action<Position, List<Position>> handler) {
            _shafts.PositionsChanged += handler;
            foreach (ILift lift in _shafts)
                lift.PositionsChanged += handler;
            foreach (IFloor floor in _floors)
                floor.PositionsChanged += handler;
        }
    }
}
