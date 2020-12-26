using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;
using static System.Math;

namespace PhysicalModel {
    public class Lift : ILift {
        public int Capacity { get; }

        private double _speed = 0.0;
        public double Speed {
            get { return _speed; }
            set { _speed = Max(0, Min(value,MaxSpeed)); }
        }
        public double MaxSpeed { get; }
        public double Acceleration { get; set; } = 0.0;
        public double MaxAcceleration { get; }

        private double _needMoveTo = 0.0;
        public double NeedMoveTo {
            get { return _needMoveTo; }
            set { _needMoveTo = Max(value, 0); }
        }

        private int _direction = 1;
        public int Direction { 
            get { return _direction; }
            set { _direction = Sign(value); }
        }       

        public Size Size { get; }

        public IArea Location { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public void SetXY(double x, double y) {
            X = x;
            Y = y;
        }
        public Position GetPosition() {
            return new LiftPosition(X, Y);
        }

        private readonly List<IPassenger> _passengers = new List<IPassenger>();

        public Lift(LiftStartingData data, double passengersSize) {
            Capacity = data.Сapacity;
            MaxSpeed = data.MaxSpeed;
            MaxAcceleration = data.MaxAcceleration;
            Size = new Size(Capacity * passengersSize*1.5, 2.5);
        }

        public bool AddPassenger(IPassenger passenger) {
            if (_passengers.Count == Capacity)
                return false;
            _passengers.Add(passenger);
            passenger.Location = this;
            return true;
        }
        public bool RemovePassenger(IPassenger passenger) {
            return _passengers.Remove(passenger);
        }

        public void ClockHandler() {
            var positions = new List<Position>(_passengers.Count);
            Parallel.ForEach(_passengers, PassengerHandleClock);
            PositionsChanged(GetPosition(), positions);

            void PassengerHandleClock(IMovable movable) {
                if (!movable.HandleClock())
                    return;
                positions.Add(movable.GetPosition());
            }
        }

        public event Action<Position,List<Position>> PositionsChanged;

        public bool HandleClock() {
            if (NeedMoveTo == 0.0) {
                Acceleration = 0;
                return true;
            }
            if (Acceleration == 0 || !CheckBrake())
                Acceleration = MaxAcceleration;
            if (0 < Speed && Speed < MaxSpeed)
                Speed += Acceleration;
            NeedMoveTo -= Speed;
            Y += Speed * Direction;
            return true;
        }

        private bool CheckBrake() {
            if (Acceleration == MaxAcceleration * -1)
                return true;
            if (NeedMoveTo <= GetBrakeWay()) {
                Acceleration = MaxAcceleration * -1;
                return true;
            }
            return false;
        }

        public double GetBrakeWay() {
            return Speed * Speed / 2 * Abs(Acceleration);
        }
    }
}
