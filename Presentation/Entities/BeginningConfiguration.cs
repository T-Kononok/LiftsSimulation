using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Entities {
    public readonly struct BeginningConfiguration {
        public int QuantityFloors { get; }
        public int QuantityLifts { get; }

        public BeginningConfiguration(int quantityFloors, int quantityLifts) {
            QuantityFloors = quantityFloors;
            QuantityLifts = quantityLifts;
        }
    }
}
