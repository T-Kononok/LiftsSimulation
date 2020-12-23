using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface IHuman : IMovable{
        public String Name { get; }
        public int StartingFloor { get; }
        public int TargetFloor { get; }
        public void TransitionTo(IHumanState state);
    }
}
