using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    static class PhysicalContext {

        public static double FloorsLength { get; } = 50.0;
        public static double WaitingAreaLength { get; } = 5.0;
        public static double HallLength { get; } = FloorsLength - WaitingAreaLength;
        public static double FloorsHeight { get; } = 3.0;
        public static double SlabsHeight { get; } = 0.5;

        public static double EntityDiameter { get; } = 0.4;
        public static int LiftCapacity { get; } = 5;

        private static int _quantityFloors = 2;
        public static int QuantityFloors {
            get {
                return _quantityFloors;
            }
        }

        public static bool SetQuantityFloors(int quantity) {
            if (QuantityFloors > 2)
                return false;
            _quantityFloors = quantity;
            return true;
        }
    }
}
