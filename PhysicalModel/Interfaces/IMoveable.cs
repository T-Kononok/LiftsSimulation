using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel.Interfaces {
    interface IMoveable {
        public Size Size { get; }

        public IArea Location { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public void RecalculatePosition();

        public Position GetPosition();
    }
}
