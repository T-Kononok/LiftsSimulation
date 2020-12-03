using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Entities {
    public abstract class EntityInfo {
        public EntityType Type { get; }

        public EntityInfo(EntityType type) => Type = type;
    }
}
