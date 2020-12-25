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

        public Shafts(List<ILift> lifts, double x, double y, double interval, double height) {
            _lifts = lifts;
            var liftX = 0.0;
            foreach (ILift lift in _lifts) {
                lift.Location = this;
                lift.X = liftX;
                lift.Y = 0.0;
                liftX += lift.Size.Height + interval;
            }
            X = x;
            Y = y;
            Size = new Size(liftX - interval, height);
        }

        public bool AddMovable(IMovable movable) {
            return false;
        }
        public bool RemoveMovable(IMovable movable) {
            return false;
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
        public void GetClockHandler(IClockGenerator generator) {
            generator.Clock += ClockHandler;
            foreach (ILift lift in _lifts)
                lift.GetClockHandler(generator);
        }

        public event Action<Position,List<Position>> PositionsChanged;

        public void SetLiftsHandlers(Action<Position, List<Position>> handler) {
            foreach (ILift lift in _lifts)
                lift.PositionsChanged += handler;
        }
    }
}
