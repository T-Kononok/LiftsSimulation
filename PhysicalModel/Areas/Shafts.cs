using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace PhysicalModel {
    class Shafts : IShafts {
        public double Interval { get; } = 3.0;

        public Size Size { get; }

        public double X { get; set; }
        public double Y { get; set; }
        public Position GetPosition() {
            return new ShaftsPosition(X,Y);
        }

        private readonly List<ILift> _lifts;

        public Shafts(List<ILift> lifts, List<IFloor> floors, double x, double y) {
            _lifts = lifts;
            X = x;
            Y = y;
            var length = 0.0;
            foreach(ILift lift in lifts) {
                length += lift.Size.Length + Interval;
            }
            length -= Interval;
            var height = 0.0;
            foreach(IFloor floor in floors) {
                height += floor.Size.Height;
            }
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
