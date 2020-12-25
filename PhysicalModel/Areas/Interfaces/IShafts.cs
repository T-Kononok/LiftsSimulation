using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface IShafts : IArea {
        public static double Interval { get; } = 3.0;
    }
}
