using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Entities {

    public readonly struct EntityLocation {
        public EntityType Type { get; }
        public double X { get; }
        public double Y { get; }

        public EntityLocation(EntityType type, double x, double y) {
            Type = type;
            X = x;
            Y = y;
        }
    }
}
