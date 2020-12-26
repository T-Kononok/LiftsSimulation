using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    public interface ILiftsHall : IArea {
        public int Number { get; }

        public delegate ILiftsHall Factory(int number, IFloor floor);

        public event Action<int, int> LiftCalling;

        public void ShowScoreboardHandler(int targetFloor, ILift lift);
        public void SuppressScoreboardHandler(int targetFloor);
    }
}
