using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public abstract class MoveableInfo {
        public Position Position { get; }

        protected MoveableInfo(Position position) {
            Position = position;
        }
    }
}
