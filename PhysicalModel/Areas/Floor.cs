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

        private readonly LinkedList<IPassenger> _passengers = new LinkedList<IPassenger>();

        public Floor(int number, double height, double x, double y, ILiftsHall.Factory factory) {
            Size = new Size(80.0, height);
            X = x;
            Y = y;
            Hall = factory(number, this);
        }     

        public bool AddPassenger(IPassenger passenger) {
            _passengers.AddFirst(passenger);
            passenger.Location = this;
            passenger.Y = 0;
            passenger.X = Size.Length * 0.9;
            return true;
        }
        public bool RemovePassenger(IPassenger passenger) {
            return _passengers.Remove(passenger);
        }

        public void ClockHandler() {
            var positions = new List<Position>(_passengers.Count);
            Parallel.ForEach(_passengers, HandleClock);
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
