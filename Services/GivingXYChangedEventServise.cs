using System;
using IModel;

namespace Services {
    public class GivingXYChangedEventServise : IGivingXYChangedEvent {

        public event IGivingXYChangedEvent.XYChangedHandler LocationsChanged;
        
        public void SetXYChangedHandler(IGivingXYChangedEvent.XYChangedHandler handler) {
            throw new NotImplementedException();
        }
    }
}
