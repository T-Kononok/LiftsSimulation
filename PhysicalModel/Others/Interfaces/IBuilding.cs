using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    public interface IBuilding {

        public bool AddPassenger(IPassenger passenger);

        public bool TurnOnAlarm();
        public bool TurnOffAlarm();

        public bool SetFloors(int quantityFloors,
            IFloor.Factory floorFactory, ILiftsHall.Factory hallFactory);

        public bool SetLifts(List<ILift> lifts, IShafts.Factory shaftsFactory);

        public bool SetManager(IManagerLifts manager);

        public bool SetGenerator(IClockGenerator generator);

        public bool SetPositionsChangedHandlers(Action<Position, List<Position>> handler);
    }
}
