using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Entities {

    public readonly struct EntityLocation {
        public EntityType Type { get; }
        public int X { get; }
        public int Y { get; }

        public EntityLocation(EntityType type, int x, int y) {
            Type = type;
            X = x;
            Y = y;
        }
    }
}
