using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalModel {
    class Floor : IFloor {

        public Size Size { get; } = new Size(100.0, 3.5);

        public double X { get; set; }
        public double Y { get; set; }

        public int Number { get; }

        public ILiftsHall Hall { get; }

        private readonly LinkedList<IMovable> _movables = new LinkedList<IMovable>();

        public Floor(int number, double x, double y, ILiftsHall.Factory factory) {
            Number = number;
            X = x;
            Y = y;
            Hall = factory(this);
        }

        public Position GetPosition() {
            return new FloorPosition(X,Y);
        }

        public bool AddMovable(IMovable movable) {
            if (!movable.Come(this))
                return false;
            _movables.AddFirst(movable);
            return true;
        }
        public bool GiveMovable(IArea area, IMovable movable) {
            if (!area.AddMovable(movable))
                return false;
            movable.Leave(this);
            _movables.Remove(movable);
            return true;
        }

        private void ClockHandler() {
            var positions = new LinkedList<Position>();
            Parallel.ForEach(_movables, RecalculateAllpositions);
            PositionsChanged(GetPosition(), positions);

            void RecalculateAllpositions(IMovable movable) {
                if (!movable.RecalculatePosition()) {
                    _movables.Remove(movable);
                    return;
                }

                positions.AddFirst(movable.GetPosition());

                if (movable.X < _hall.Size.Length)
                    if (!GiveMovable(_hall, movable))
                        movable.X += 0.1 * Size.Length;
            }

        }
        
        public void GetClockHandler(IClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }

        event IArea.PositionsChangedHandler PositionsChanged;
        public void SetPositionsChangedHandler(IArea.PositionsChangedHandler handler) {
            PositionsChanged += handler;
        }

        
    }
}
