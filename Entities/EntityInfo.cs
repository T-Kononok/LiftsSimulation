
namespace Entities {
    public abstract class EntityInfo {
        public EntityType Type { get; }

        public EntityInfo(EntityType type) => Type = type;
    }
}
