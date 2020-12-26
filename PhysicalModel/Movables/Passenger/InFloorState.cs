using System;
using System.Collections.Generic;
using System.Text;
using PhysicalModel.Movables.Passenger;

namespace PhysicalModel{
    public class InFloorState : IPassengerState {

        private IPassenger _passenger;
        private double _speed = 5.0;

        public bool HandleClock() {
            _passenger.X -= _speed;
            if (_passenger.X < 0) {
                IFloor floor = (IFloor)(_passenger.Location);
                if (floor.Hall.AddPassenger(_passenger)) {
                    floor.RemovePassenger(_passenger);
                    _passenger.TransitionTo(new InHallState());
                } else
                    _passenger.X += 0.5 * floor.Size.Length;
            }
            return true;
        }

        public void SetContext(IPassenger context) {
            _passenger = context;
        }
    }
}
