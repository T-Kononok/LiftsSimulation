using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    public class Passenger : IPassenger {

        private IPassengerState _state;
 
        public string Name { get; }
        public int StartingFloor { get; }
        public int TargetFloor { get; }

        public Size Size { get; } = new Size(1.0, 1.0);

        public IArea Location { get; set; }  
        public double X { get; set; }
        public double Y { get; set; }
        public void SetXY(double x, double y) {
            X = x;
            Y = y;
        }
        public Position GetPosition() {
            return new PassengerPosition(X, Y);
        }

        public Passenger(PassengerStartingData data, IPassengerState state) {
            Name = data.Name;
            StartingFloor = data.StartingFloor;
            TargetFloor = data.TargetFloor;
            TransitionTo(state);
        }
        public void TransitionTo(IPassengerState state) {
            _state = state;
            _state.SetContext(this);
        }

        public bool HandleClock() {
            return _state.HandleClock();
        }       
    }
}
