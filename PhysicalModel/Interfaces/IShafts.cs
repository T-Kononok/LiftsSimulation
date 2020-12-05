using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface IShafts : IArea {

        public static double Interval { get; } = 4.0;

        public double Length { get; }

        public void SetManager(LiftsManager manager);

    }
}
