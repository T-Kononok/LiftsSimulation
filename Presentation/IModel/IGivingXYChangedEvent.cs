using Entities;
using System.Collections.Generic;

namespace Presentation.IModel {
    public interface IGivingXYChangedEvent {

        public delegate void XYChangedHandler(List<EntityLocation> locations);
        event XYChangedHandler LocationsChanged;
        public void SetXYChangedHandler(XYChangedHandler handler);
    }
}
