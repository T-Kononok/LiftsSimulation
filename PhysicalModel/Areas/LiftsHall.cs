using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace PhysicalModel {
    public class LiftsHall : ILiftsHall {
             
        public Size Size { get; }

        public double X { get; set; }
        public double Y { get; set; }
        public Position GetPosition() {
            return new LiftsHallPosition(X, Y);
        }

        public int Number { get; }

        private readonly LinkedList<IPassenger> _passengers = new LinkedList<IPassenger>();

        private Dictionary<int, ILift> _waitingMap = new Dictionary<int, ILift>();

        public ILift CheckOpenedLift(int floorNumber) {
            if (_waitingMap.ContainsKey(floorNumber-1) &&
                _waitingMap[floorNumber-1].Y == Y)
                return _waitingMap[floorNumber-1];
            return null;
        }

        public LiftsHall(int number, IFloor floor) {
            Size = new Size(20.0, floor.Size.Height);
            Number = number;
            X = floor.X - Size.Length;
            Y = floor.Y;
        }       

        public bool AddPassenger(IPassenger passenger) {
            _passengers.AddFirst(passenger);
            passenger.Location = this;
            LiftCalling(passenger.StartingFloor, passenger.TargetFloor);
            return true;
        }
        public bool RemovePassenger(IPassenger passenger) {
            return _passengers.Remove(passenger);
        }

        public void ClockHandler() {
            var positions = new List<Position>(_passengers.Count);
            Parallel.ForEach(_passengers, HandleClock);

            void HandleClock(IMovable movable) {
                if (!movable.HandleClock())
                    return;
                positions.Add(movable.GetPosition());
            }

            PositionsChanged(GetPosition(), positions);

            foreach (KeyValuePair<int, ILift> pair in _waitingMap) {
                if (pair.Value.Y == Y)
                    _waitingMap.Remove(pair.Key);
            }
        }

        public event Action<Position,List<Position>> PositionsChanged;

        public void ShowScoreboard(int targetFloor, ILift lift) {
            Console.WriteLine("Show " + targetFloor + " от лифта " + lift.Y);
            _waitingMap.Add(targetFloor,lift);
        }

        public void CallLift(int startingFloor, int targetFloor) {
            LiftCalling(startingFloor, targetFloor);
        }

        public event Action<int, int> LiftCalling;
    }
}
