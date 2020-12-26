using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    public interface IPassengerState {
        public void SetContext(IPassenger context);
        public bool HandleClock();
    }
}
