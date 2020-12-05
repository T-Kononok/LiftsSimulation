using Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface IEntity {
        public static double Diameter { get; } = 0.4;

        public EntityType Type { get; }

        public IArea Source { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public bool RecalculateLocation();

        public EntityLocation GetLocation();
    }
}
