using System;
using System.Collections.Generic;
using Entities;
using IModel;
using PhysicalModel;

namespace Services {
    public class GivingXYChangedEventServise : IGivingXYChangedEvent {

        public GivingXYChangedEventServise(IBuilding building) {
            building.SetPositionsChangedHandlers(Handler);
        }

        public event Action<Position, List<Position>> PositionsChanged;

        private void Handler(Position position, List<Position> list) {
            PositionsChanged(position, list);
        }
    }
}
