using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    public interface IShafts : IArea {

        public delegate IShafts Factory(List<ILift> lifts, double x, double y,
            double interval, double height);

        public IEnumerator GetEnumerator();
    }
}
