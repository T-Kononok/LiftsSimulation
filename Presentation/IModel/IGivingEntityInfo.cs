﻿using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;

namespace Presentation.IModel {
    public interface IGivingEntityInfo {
        HumanInfo GetEntityInfo(EntityLocation location);
    }
}
