
using System.Collections.Generic;

namespace Entities {
    public readonly struct BeginningConfiguration {
        public int QuantityFloors { get; }
        public LinkedList<LiftStartingData> Lifts { get; }

        public BeginningConfiguration(int quantityFloors, LinkedList<LiftStartingData> lifts) {
            QuantityFloors = quantityFloors;
            Lifts = lifts;
        }
    }
}
