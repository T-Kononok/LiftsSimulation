using System;
using IModel;

namespace Services {
    public class GivingXYChangedEventServise : IGivingXYChangedEvent {

        public event IGivingXYChangedEvent.XYChangedHandler PositionsChanged;

        public void SetXYChangedHandler(IGivingXYChangedEvent.XYChangedHandler handler) {
            throw new NotImplementedException();
        }
    }
}
