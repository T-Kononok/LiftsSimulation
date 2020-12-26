using System;

namespace Entities {
    public class PassengerStartingData {
        public String Name { get; }
        public int StartingFloor { get; }
        public int TargetFloor { get; }

        public PassengerStartingData(String name, int startingFloor, int targetFloor) {
            Name = name;
            StartingFloor = startingFloor;
            TargetFloor = targetFloor;
        }
    }
}
