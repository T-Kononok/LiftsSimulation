using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Entities {
    public class HumanInfo : EntityInfo {
        public String Name { get; }
        public int StartingFloor { get; }
        public int TargetFloor { get; }
        public int TravelTime { get; }
        public int WaitingTime { get; }
        public bool IsDelivered { get; }

        public HumanInfo(String name, int startingFloor, int targetFloor, int travelTime,
            int waitingTime, bool isDelivered) : base(EntityType.Human) {
            Name = name;
            StartingFloor = startingFloor;
            TargetFloor = targetFloor;
            TravelTime = travelTime;
            WaitingTime = waitingTime;
            IsDelivered = isDelivered;
        }
    }
}
