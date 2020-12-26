using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface IPassengerState {
        public void SetContext(IPassenger context);
        public bool HandleClock();
    }
}
