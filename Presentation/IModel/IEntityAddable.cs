using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;

namespace Presentation.IModel {
    interface IEntityAddable {
        bool AddEntity(EntityStartingData data);
    }
}
