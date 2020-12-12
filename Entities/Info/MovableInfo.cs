using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public abstract class MovableInfo {
        public Position Position { get; }

        protected MovableInfo(Position position) {
            Position = position;
        }
    }
}
