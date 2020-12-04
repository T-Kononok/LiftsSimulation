using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;

namespace PhysicalModel {
    abstract class Entity {
        public String Name { get; } = "";
        public EntityType Type { get; } = EntityType.Unknown;
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;

        public Entity(String name, EntityType type, double x, double y) {
            Name = name;
            Type = type;
            X = x;
            Y = y;
        }

        public abstract bool RecalculateLocation();

        public abstract EntityLocation GetLocation();
    }
}
