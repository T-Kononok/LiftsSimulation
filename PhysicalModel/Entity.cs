using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;

namespace PhysicalModel {
    public abstract class Entity {
        public String Name { get; } = "";
        public EntityType Type { get; } = EntityType.Unknown;
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public Entity(String name, EntityType type, int x, int y) {
            Name = name;
            Type = type;
            X = x;
            Y = y;
        }

        public abstract void RecalculateLocation();

        public abstract EntityLocation GetLocation();
    }
}
