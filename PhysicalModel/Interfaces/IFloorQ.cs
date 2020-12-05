using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface IFloorQ<Q> : IFloor
        where Q : IHQueue, new() {

        public void SetManager(LiftsManager manager);

    }
}
