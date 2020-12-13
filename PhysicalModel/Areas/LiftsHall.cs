using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    class LiftsHall : ILiftsHall {

        public int Number { get; }

        public Size Size { get; } = new Size(20.0, 3.5);

        public double X { get; set; }
        public double Y { get; set; }

        public static LiftsHall Factory(IFloor floor) {
             return new LiftsHall(floor);
        }

        private LiftsHall() { }

        private LiftsHall(IFloor floor) {
            Number = floor.Number;
            X = floor.X;
            Y = floor.Y;
        }

        public bool AddMovable(IMovable movable) {
            throw new NotImplementedException();
        }    

        public void GetClockHandler(IClockGenerator generator) {
            throw new NotImplementedException();
        }

        public Position GetPosition() {
            throw new NotImplementedException();
        }

        public bool GiveMovable(IArea area, IMovable movable) {
            throw new NotImplementedException();
        }

        public void SetPositionsChangedHandler(IArea.PositionsChangedHandler handler) {
            throw new NotImplementedException();
        }
    }
}
