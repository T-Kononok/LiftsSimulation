using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public abstract class Position {
        public double X { get; set; }
        public double Y { get; set; }

        protected Position(double x, double y) {
            X = x;
            Y = y;
        }
    }
}