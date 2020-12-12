using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public class Size {
        public double Length { get; }
        public double Height { get; }

        public Size(double length, double height) {
            Length = length;
            Height = height;
        }
    }
}
