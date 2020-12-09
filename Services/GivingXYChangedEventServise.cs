using System;
using IModel;

namespace Services {
    class GivingXYChangedEventServise : IGivingXYChangedEvent {

        public event IGivingXYChangedEvent.XYChangedHandler LocationsChanged;
        
        public void SetXYChangedHandler(IGivingXYChangedEvent.XYChangedHandler handler) {
            throw new NotImplementedException();
        }
    }
}
