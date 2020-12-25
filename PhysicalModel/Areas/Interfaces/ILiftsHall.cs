using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface ILiftsHall : IArea {
        public int Number { get; }

        public delegate ILiftsHall Factory(int number, IFloor floor);
    }
}
