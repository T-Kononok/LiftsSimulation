using System;
using System.Collections.Generic;
using System.Text;
using static PhysicalModel.PhysicalContext;

namespace PhysicalModel {
    class WaitingArea {

        private Queue<Entity> _entities = new Queue<Entity>();

        public double X { get; set; } = 0;

        public WaitingArea(double x) {
            X = x;
        }

        public void EnqueueEntity(Entity entity) {
            RelocateEntity(entity);
            _entities.Enqueue(entity);
        }

        private void RelocateEntity(Entity entity) {
            entity.X = X + _entities.Count * EntityDiameter * 1.5;
        }

        public Stack<Entity> FillLift(Lift lift) {
            var stack = new Stack<Entity>();
            for (var i = 0; i < LiftCapacity - lift.GetCount(); i++) {
                if (_entities.Count == 0)
                    break;
                stack.Push(_entities.Dequeue());
            }
            foreach (Entity e in _entities)
                RelocateEntity(e);
            return stack;
        }
    }
}
