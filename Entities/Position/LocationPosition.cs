using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public class LocationPosition {
        public double X { get; }
        public double Y { get; }

        public LocationPosition(double x, double y) {
            X = x;
            Y = y;
        }
    }
}
