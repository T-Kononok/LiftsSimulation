using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PhysicalModel.Movables.Passenger {
    class InLiftState : IPassengerState {

        private IPassenger _passenger;

        public bool HandleClock() {

            ILift lift = (ILift)_passenger.Location;

            if (lift.NeedMoveTo != 0)
                _passenger.X = 0;
            else {
                _passenger.X += 30.0;
                lift.RemovePassenger(_passenger);
            }

            return true;
        }

        public void SetContext(IPassenger context) {
            _passenger = context;
        }
    }
}
