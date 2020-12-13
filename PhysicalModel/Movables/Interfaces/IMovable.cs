using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    interface IMovable : IMaterial {

        public IArea Location { get; set; }

        public void SetXY(double x, double y);

        public void Leave(IArea area);

        public bool Come(IArea area);

        public bool RecalculatePosition();

        public Position GetPosition();
    }
}
