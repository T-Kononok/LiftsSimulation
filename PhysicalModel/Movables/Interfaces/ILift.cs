using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface ILift : IArea, IMovable {
        public int Capacity { get; }
        public double Speed { get; }
        public double MaxSpeed { get; }
        public double Acceleration { get; }
        public double MaxAcceleration { get; }
    }
}
