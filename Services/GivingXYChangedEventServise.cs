﻿using System;
using Presentation.IModel;

namespace Services {
    class GivingXYChangedEventServise : IGivingXYChangedEvent {

        public event IGivingXYChangedEvent.XYChangedHandler LocationsChanged;
        
        public void SetXYChangedHandler(IGivingXYChangedEvent.XYChangedHandler handler) {
            throw new NotImplementedException();
        }
    }
}
