
using Entities;

namespace Presentation.IModel {
    public interface IGivingEntityInfo {
        HumanInfo GetEntityInfo(EntityLocation location);
    }
}
