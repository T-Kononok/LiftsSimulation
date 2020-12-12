using System;

namespace Entities {
    public class HumanInfo : MovableInfo {
        public String Name { get; }
        public int StartingFloor { get; }
        public int TargetFloor { get; }
        public int TravelTime { get; }
        public int WaitingTime { get; }
        public bool IsDelivered { get; }

        public HumanInfo(HumanPosition position, String name, int startingFloor,
            int targetFloor, int travelTime, int waitingTime, bool isDelivered)
            : base(position) {
            Name = name;
            StartingFloor = startingFloor;
            TargetFloor = targetFloor;
            TravelTime = travelTime;
            WaitingTime = waitingTime;
            IsDelivered = isDelivered;
        }
    }
}
