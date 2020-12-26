using Entities;
using System;
using System.Collections.Generic;

namespace IModel {
    public interface IGivingXYChangedEvent {

        public event Action<Position, List<Position>> PositionsChanged;
    }
}
