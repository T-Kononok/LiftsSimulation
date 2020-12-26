using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    public interface IPassenger : IMovable{
        public String Name { get; }
        public int StartingFloor { get; }
        public int TargetFloor { get; }
        public void TransitionTo(IPassengerState state);
    }
}
