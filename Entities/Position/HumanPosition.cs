using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public class HumanPosition : Position {
        public HumanPosition(LocationPosition location, double x, double y)
            : base(location, x, y) { }
    }
}
