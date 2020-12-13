
using System.Collections.Generic;
using Entities;

namespace PhysicalModel {
    interface IArea : IMaterial {

        public Position GetPosition();

        public bool AddMovable(IMovable movable);
        public bool GiveMovable(IArea area, IMovable movable);

        public delegate void PositionsChangedHandler(Position location, LinkedList<Position> positions);
        public void SetPositionsChangedHandler(PositionsChangedHandler handler);

        public void GetClockHandler(IClockGenerator generator);
    }
}
