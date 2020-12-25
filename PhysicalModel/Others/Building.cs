using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel.Others {
    class Building : IBuilding {
        public Size Size { get; }
        public double Interval { get; } = 3.0;

        private readonly List<IFloor> _floors = new List<IFloor>();
        private readonly IShafts _shafts;

        public Building(int quantityFloors, List<ILift> lifts, IFloor.Factory floorFactory,
            ILiftsHall.Factory hallFactory, IShafts.Factory shaftsFactory) {

            _shafts = shaftsFactory(lifts, 0.0, 0.0, Interval, quantityFloors*3.5+3.5);

            _floors.Add(floorFactory(1, 7.0, 0.0, 0.0, hallFactory));
            for (var i = 1; i < quantityFloors; i++) {
                _floors.Add(floorFactory(i+1, 3.5, 0.0, 3.5+i*3.5, hallFactory));
            }
        }

        public bool AddMovable(IMovable movable, int floorNumber) {
            return _floors[floorNumber].AddMovable(movable);
        }

        public bool TurnOffAlarm() {
            throw new NotImplementedException();
        }

        public bool TurnOnAlarm() {
            throw new NotImplementedException();
        }
    }
}
