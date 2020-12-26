using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    public interface ILiftsHall : IArea {
        public int Number { get; }

        public delegate ILiftsHall Factory(int number, IFloor floor);

        public event Action<int, int> LiftCalling;

        public ILift CheckOpenedLift(int floorNumber);

        public void CallLift(int startingFloor, int targetFloor);

        public void ShowScoreboard(int targetFloor, ILift lift);
    }
}
