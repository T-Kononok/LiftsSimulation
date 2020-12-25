using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    interface IMovable : IMaterial {

        public IArea Location { get; set; }

        public void SetXY(double x, double y);

        public Position GetPosition();

        public bool HandleClock();

        
    }
}
