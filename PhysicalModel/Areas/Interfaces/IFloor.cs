using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    interface IFloor : IArea {

        public ILiftsHall Hall { get; }

        public delegate IFloor Factory(int number, double height, double x, double y,
            ILiftsHall.Factory factory);
    }
}
