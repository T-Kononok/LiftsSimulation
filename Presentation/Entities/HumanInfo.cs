using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Entities {
    public readonly struct HumanInfo {

        public String Name { get; }
        public int StartingFloor { get; }
        public int TargetFloor { get; }
        public int TravelTime { get; }
        public int WaitingTime { get; }
        public bool IsDelivered { get; }

    }
}
