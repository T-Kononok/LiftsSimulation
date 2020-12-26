using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel{
    public class PassengerState1 : IPassengerState {
        public bool HandleClock() {
            return true;
        }

        public void SetContext(IPassenger context) {
            
        }
    }
}
