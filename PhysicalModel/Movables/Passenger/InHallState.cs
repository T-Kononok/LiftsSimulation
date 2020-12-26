using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Movables.Passenger {
    class InHallState : IPassengerState {

        private IPassenger _passenger;

        public bool HandleClock() {

            ILiftsHall hall = (ILiftsHall)_passenger.Location;
            ILift lift = hall.CheckOpenedLift(_passenger.TargetFloor);

            Console.WriteLine(lift);
            if (lift != null && lift.Y == hall.Y)
                if (lift.AddPassenger(_passenger)) {
                    hall.RemovePassenger(_passenger);
                    _passenger.TransitionTo(new InLiftState());
                } else {
                    hall.CallLift(_passenger.StartingFloor, _passenger.TargetFloor);
                }
            return true;
        }

        public void SetContext(IPassenger context) {
            _passenger = context;
        }
    }
}
