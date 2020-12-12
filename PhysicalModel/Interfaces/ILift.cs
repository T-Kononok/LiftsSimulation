﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface ILift : IArea, IMovable {
        public int Сapacity { get; }
        public double MaxSpeed { get; }
        public double MaxAcceleration { get; }
    }
}
