using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface IFloor : IArea {
        public int Number { get; }

        public ILiftsHall Hall { get; }
    }
}
