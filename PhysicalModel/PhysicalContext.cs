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

        public static double LiftLength { get; } = LiftCapacity * EntityDiameter * 1.5;

        public static double LiftHeight { get; } = 2.5;

        public static double LiftInterval { get; } = 1.0;

        public static double AllLiftLength {
            get {
                return QuantityLifts * (LiftLength + LiftInterval) - LiftInterval;
            }
        }

        private static int _quantityFloors = 2;
        public static int QuantityFloors {
            get {
                return _quantityFloors;
            }
        }

        public static bool SetQuantityFloors(int quantity) {
            if (QuantityFloors > 2 || quantity < 2)
                return false;
            _quantityFloors = quantity;
            return true;
        }

        private static int _quantityLifts = 1;
        public static int QuantityLifts {
            get {
                return _quantityLifts;
            }
        }

        public static bool SetQuantityLifts(int quantity) {
            if (QuantityLifts > 1 || quantity < 1)
                return false;
            _quantityLifts = quantity;
            return true;
        }
    }
}
