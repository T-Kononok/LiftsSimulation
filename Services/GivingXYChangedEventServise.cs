using System;
using System.Collections.Generic;
using System.Text;
using Presentation.IModel;
using Presentation.Entities;

namespace Services {
    class GivingXYChangedEventServise : IGivingXYChangedEvent {

        public event IGivingXYChangedEvent.XYChangedHandler LocationsChanged;
        
        public void SetXYChangedHandler(IGivingXYChangedEvent.XYChangedHandler handler) {
            throw new NotImplementedException();
        }
    }
}
