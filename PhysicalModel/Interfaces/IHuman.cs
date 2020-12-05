using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface IHuman : IEntity {

        public String Name { get; }

        public bool IsArrival { get; set; }

        public int TargetFloor { get; }

    }
}
