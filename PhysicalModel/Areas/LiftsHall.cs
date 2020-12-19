using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    class LiftsHall : ILiftsHall {
             
        public Size Size { get; } = new Size(20.0, 3.5);

        public double X { get; set; }
        public double Y { get; set; }

        public int Number { get; }

        private readonly LinkedList<IMovable> _movables = new LinkedList<IMovable>();      

        public static LiftsHall Factory(IFloor floor) {
             return new LiftsHall(floor);
        }

        private LiftsHall() { }

        private LiftsHall(IFloor floor) {
            Number = floor.Number;
            X = floor.X - Size.Length;
            Y = floor.Y;
        }

        public Position GetPosition() {
            return new FloorPosition(X, Y);
        }

        public bool AddMovable(IMovable movable) {
            _movables.AddFirst(movable);
            return true;
        }
        public bool RemoveMovable(IMovable movable) {
            return _movables.Remove(movable);
        }

        public void GetClockHandler(IClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }

        private void ClockHandler() {
            var positions = new LinkedList<Position>();
            foreach(IMovable movable in _movables) {
                if (!movable.HandleClock())
                    continue;
                positions.AddFirst(movable.GetPosition());
            }
            PositionsChanged(GetPosition(), positions);
        }

        event Action<Position,LinkedList<Position>> PositionsChanged;
        public void SetPositionsChangedHandler(Action<Position, LinkedList<Position>> handler) {
            PositionsChanged += handler;
        }
    }
}
