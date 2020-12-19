
using System;
using System.Collections.Generic;
using Entities;

namespace PhysicalModel {
    interface IArea : IMaterial {

        public Position GetPosition();

        public bool AddMovable(IMovable movable);
        public bool RemoveMovable(IMovable movable);

        public void SetPositionsChangedHandler(Action<Position, List<Position>> handler);

        public void GetClockHandler(IClockGenerator generator);
    }
}
