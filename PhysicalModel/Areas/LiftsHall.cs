using System;
using System.Collections.Generic;
using System.Text;
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
            if (_waitingMap.ContainsKey(floorNumber) &&
                _waitingMap[floorNumber].Y == Y)
                return _waitingMap[floorNumber];
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
            foreach(IMovable movable in _passengers) {
                if (!movable.HandleClock())
                    continue;
                positions.Add(movable.GetPosition());
            }
            PositionsChanged(GetPosition(), positions);
        }

        public event Action<Position,List<Position>> PositionsChanged;

        public void ShowScoreboardHandler(int targetFloor, ILift lift) {
            _waitingMap.Add(targetFloor,lift);
        }
        public void SuppressScoreboardHandler(int targetFloor) {
            _waitingMap.Remove(targetFloor);
        }

        public event Action<int, int> LiftCalling;
    }
}
