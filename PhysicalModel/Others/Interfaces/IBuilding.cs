using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    interface IBuilding {
        public Size Size { get; }

        public bool AddPassenger(IPassenger passenger);

        public bool TurnOnAlarm();
        public bool TurnOffAlarm();

        public void SetPositionsChangedHandlers(Action<Position, List<Position>> handler);
    }
}
