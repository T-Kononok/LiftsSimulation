using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface IShafts : IArea {
        public double Interval { get; }
    }
}
