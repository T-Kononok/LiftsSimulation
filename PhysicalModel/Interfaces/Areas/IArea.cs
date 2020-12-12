
using System.Collections.Generic;
using Entities;

namespace PhysicalModel.Interfaces {
    interface IArea {

        public Size Size { get; }

        public double X { get; set; }
        public double Y { get; set; }

        public void SetXY(double x, double y);
        public Position GetPosition();

        public bool AddMovable(IMovable movable);
        public bool GiveMovable(IArea area, IMovable movable);

        public delegate void PositionsChangedHandler(Position location, LinkedList<Position> positions);
        public void SetPositionsChangedHandler(PositionsChangedHandler handler);

        public void GetClockHandler(IClockGenerator generator);
    }
}
