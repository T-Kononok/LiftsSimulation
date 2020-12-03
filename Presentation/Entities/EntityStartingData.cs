using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Entities {
    public abstract class EntityStartingData {
        public EntityType Type { get; }

        public EntityStartingData(EntityType type) => Type = type;
    }
}
