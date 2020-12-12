using System;

namespace Entities {
    public class HumanStartingData {
        public String Name { get; }
        public int StartingFloor { get; }
        public int TargetFloor { get; }

        public HumanStartingData(String name, int startingFloor, int targetFloor) {
            Name = name;
            StartingFloor = startingFloor;
            TargetFloor = targetFloor;
        }
    }
}
