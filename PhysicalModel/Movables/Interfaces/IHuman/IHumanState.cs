using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface IHumanState {
        public void SetContext(IHuman context);
        public bool HandleClock();
    }
}
