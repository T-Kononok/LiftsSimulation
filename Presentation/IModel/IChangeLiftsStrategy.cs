using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.IModel {
    interface IChangeLiftsStrategy {
        void ChangeLiftsStrategy(LiftsStrategies strategy);
    }

    public enum LiftsStrategies {
        Fire,
        MinTimeout,
        MinIdling,
        MinDeliveryTime
    }
}
