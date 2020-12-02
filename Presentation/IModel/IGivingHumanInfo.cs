using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;

namespace Presentation.IModel {
    interface IGivingHumanInfo {
        public HumanInfo GetHumanInfo(EntityLocation location);
    }
}
