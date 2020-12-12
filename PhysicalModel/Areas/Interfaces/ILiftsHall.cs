using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface ILiftsHall : IArea {
        public int MaxCount { get; }
    }
}
