using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public class LiftStartingData {
        public int Сapacity { get; }
        public double MaxSpeed { get; }
        public double MaxAcceleration { get; }

        public LiftStartingData(int capacity, double maxSpeed, double maxAcceleration) {
            Сapacity = capacity;
            MaxSpeed = maxSpeed;
            MaxAcceleration = maxAcceleration;
        }
    }
}
