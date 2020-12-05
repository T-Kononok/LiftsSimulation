using Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static PhysicalModel.PhysicalContext;

namespace PhysicalModel {
    class Lift : Entity {

        Stack<Entity> _entities = new Stack<Entity>();
        public int GetCount() { return _entities.Count; }

        private double _speed = 1.8;

        public Lift(double x) 
            : base($"Лифт{x}",EntityType.Lift,x,SlabsHeight+LiftHeight) {
        }

        public override EntityLocation GetLocation() {
            return new EntityLocation(EntityType.Lift, X, Y);
        }

        public override bool RecalculateLocation() {
            throw new NotImplementedException();
        }

        public void FillLift() {

        }
    }
}
