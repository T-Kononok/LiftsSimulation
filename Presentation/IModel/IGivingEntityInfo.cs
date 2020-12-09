
using Presentation.Entities;

namespace Presentation.IModel {
    public interface IGivingEntityInfo {
        HumanInfo GetEntityInfo(EntityLocation location);
    }
}
