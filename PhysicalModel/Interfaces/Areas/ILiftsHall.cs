using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface ILiftsHall : IArea {
        public int MaxCount { get; }
    }
}
