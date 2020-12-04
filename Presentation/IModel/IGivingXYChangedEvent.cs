using Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Presentation.IModel {
    public interface IGivingXYChangedEvent {

        public delegate void XYChangedHandler(LinkedList<EntityLocation> locations);
        event XYChangedHandler LocationsChanged;
        public void SetXYChangedHandler(XYChangedHandler handler);
    }
}
