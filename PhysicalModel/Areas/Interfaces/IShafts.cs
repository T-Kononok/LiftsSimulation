using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface IShafts : IArea {
        public delegate IShafts Factory(List<ILift> lifts, double x, double y,
            double interval, double height);
    }
}
