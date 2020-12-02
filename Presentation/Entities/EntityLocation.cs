using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Entities {

    public readonly struct EntityLocation {
        public Entities Entities { get; }
        public int X { get; }
        public int Y { get; }
    }

    public enum Entities {
        Unknown,
        Lift,
        Human
    }
}
