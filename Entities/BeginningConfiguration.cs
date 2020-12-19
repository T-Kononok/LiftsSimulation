
using System.Collections.Generic;

namespace Entities {
    public readonly struct BeginningConfiguration {
        public int QuantityFloors { get; }
        public List<LiftStartingData> Lifts { get; }

        public BeginningConfiguration(int quantityFloors, List<LiftStartingData> lifts) {
            QuantityFloors = quantityFloors;
            Lifts = lifts;
        }
    }
}
