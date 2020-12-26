using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    public interface ILift : IArea, IMovable {
        public int Capacity { get; }
        public double Speed { get; }
        public double MaxSpeed { get; }
        public double Acceleration { get; }
        public double MaxAcceleration { get; }

        public double NeedMoveTo { get; set; }
        public int Direction { get; set; }

        public double GetBrakeWay();
    }
}
