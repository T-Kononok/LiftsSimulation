using Entities;
using System.Collections.Generic;

namespace IModel {
    public interface IGivingXYChangedEvent {

        public delegate void XYChangedHandler(List<Position> positions);
        event XYChangedHandler PositionsChanged;
        public void SetXYChangedHandler(XYChangedHandler handler);
    }
}
