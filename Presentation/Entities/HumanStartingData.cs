using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Entities {
    public class HumanStartingData : EntityStartingData {
        public String Name { get; }
        public int StartingFloor { get; }
        public int TargetFloor { get; }

        public HumanStartingData(String name, int startingFloor, int targetFloor)
            : base(EntityType.Human) {
            Name = name;
            StartingFloor = startingFloor;
            TargetFloor = targetFloor;
        }
    }
}
