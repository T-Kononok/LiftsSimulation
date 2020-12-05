using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;
using PhysicalModel.Interfaces;

namespace PhysicalModel {
    abstract class Entity : IEntity {

        public EntityType Type { get; } = EntityType.Unknown;

        public IArea Source { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Entity(EntityType type, double x, double y) {
            Type = type;
            X = x;
            Y = y;
        }

        public abstract bool RecalculateLocation();

        public abstract EntityLocation GetLocation();
    }
}
