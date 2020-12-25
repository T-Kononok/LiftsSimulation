using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalModel {
    class Floor : IFloor{

        public Size Size { get; }

        public double X { get; set; }
        public double Y { get; set; }
        public Position GetPosition() {
            return new FloorPosition(X, Y);
        }

        public ILiftsHall Hall { get; }

        private readonly LinkedList<IMovable> _movables = new LinkedList<IMovable>();

        public Floor(int number, double height, double x, double y, ILiftsHall.Factory factory) {
            Size = new Size(80.0, height);
            X = x;
            Y = y;
            Hall = factory(number, this);
        }     

        public bool AddMovable(IMovable movable) {
            _movables.AddFirst(movable);
            movable.Location = this;
            movable.Y = 0;
            movable.X = Size.Length * 0.9;
            return true;
        }
        public bool RemoveMovable(IMovable movable) {
            return _movables.Remove(movable);
        }        

        private void ClockHandler() {
            var positions = new List<Position>(_movables.Count);
            Parallel.ForEach(_movables, HandleClock);
            PositionsChanged(GetPosition(), positions);

            void HandleClock(IMovable movable) {
                if (!movable.HandleClock())
                    return;
                positions.Add(movable.GetPosition());
            }
        }
        public void GetClockHandler(IClockGenerator generator) {
            generator.Clock += ClockHandler;
            Hall.GetClockHandler(generator);
        }

        public event Action<Position,List<Position>> PositionsChanged;    
    }
}
