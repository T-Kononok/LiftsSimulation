
namespace Entities {
    public abstract class EntityStartingData {
        public EntityType Type { get; }

        public EntityStartingData(EntityType type) => Type = type;
    }
}
