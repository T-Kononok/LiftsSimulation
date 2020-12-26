
using System;
using System.Collections.Generic;
using Entities;

namespace PhysicalModel {
    public interface IArea : IMaterial {

        public Position GetPosition();       

        public bool AddPassenger(IPassenger passenger);
        public bool RemovePassenger(IPassenger passenger);

        public void ClockHandler();

        public event Action<Position, List<Position>> PositionsChanged;       
    }
}
