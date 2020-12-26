using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    public interface IMaterial {
        public Size Size { get; }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
