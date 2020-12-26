using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace PhysicalModel {
    public class Shafts : IShafts {
        public Size Size { get; }

        public double X { get; set; }
        public double Y { get; set; }
        public Position GetPosition() {
            return new ShaftsPosition(X,Y);
        }

        private readonly List<ILift> _lifts;

        public IEnumerator GetEnumerator() {
            for (int i = 0; i < _lifts.Count; i++) {
                yield return _lifts[i];
            }
        }

        public Shafts(List<ILift> lifts, double x, double y, double interval, double height) {
            _lifts = lifts;
            var liftX = 0.0;
            foreach (ILift lift in _lifts) {
                lift.Location = this;
                lift.X = liftX;
                lift.Y = 0.0;
                liftX += lift.Size.Length + interval;
            }
            X = x;
            Y = y;
            Size = new Size(liftX - interval, height);
        }

        public bool AddPassenger(IPassenger passenger) {
            return false;
        }
        public bool RemovePassenger(IPassenger passenger) {
            return false;
        }

        public void ClockHandler() {
            var positions = new List<Position>(_lifts.Count);
            Parallel.ForEach(_lifts, HandleClock);
            PositionsChanged(GetPosition(), positions);

            void HandleClock(IMovable movable) {
                if (!movable.HandleClock())
                    return;
                positions.Add(movable.GetPosition());
            }
        }

        public event Action<Position,List<Position>> PositionsChanged;
    }
}
