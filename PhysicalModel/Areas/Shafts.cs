using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace PhysicalModel {
    class Shafts : IShafts {
        public Size Size { get; }

        public double X { get; set; }
        public double Y { get; set; }
        public Position GetPosition() {
            return new ShaftsPosition(X,Y);
        }

        private readonly List<ILift> _lifts;

        public Shafts(List<ILift> lifts, double x, double y, double length, double height) {
            _lifts = lifts;
            foreach (ILift lift in _lifts) {
                lift.Location = this;
            }
            X = x;
            Y = y;
            Size = new Size(length, height);
        }

        public bool AddMovable(IMovable movable) {
            return false;
        }
        public bool RemoveMovable(IMovable movable) {
            return false;
        }

        public void GetClockHandler(IClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }

        private void ClockHandler() {
            var positions = new List<Position>(_lifts.Count);
            Parallel.ForEach(_lifts, HandleClock);
            PositionsChanged(GetPosition(), positions);

            void HandleClock(IMovable movable) {
                if (!movable.HandleClock())
                    return;
                positions.Add(movable.GetPosition());
            }
        }

        event Action<Position,List<Position>> PositionsChanged;
        public void SetPositionsChangedHandler(Action<Position, List<Position>> handler) {
            PositionsChanged += handler;
        }
    }
}
