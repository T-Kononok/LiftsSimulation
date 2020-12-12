using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public class LiftPosition : Position {
        public LiftPosition(LocationPosition location, double x, double y)
            : base(location, x, y) { }
    }
}
