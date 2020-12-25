using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    interface IShafts : IArea {

        public delegate IShafts Factory(List<ILift> lifts, double x, double y,
            double interval, double height);

        public void SetLiftsHandlers(Action<Position, List<Position>> handler);
    }
}
