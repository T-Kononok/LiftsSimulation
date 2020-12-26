using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Movables.Passenger {
    class InHallState : IPassengerState {

        private IPassenger _passenger;

        public bool HandleClock() {
            _passenger.X = 0;
            return true;
        }

        public void SetContext(IPassenger context) {
            _passenger = context;
        }
    }
}
