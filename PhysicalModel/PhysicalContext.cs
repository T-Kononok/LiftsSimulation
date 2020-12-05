using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    static class PhysicalContext {

        public static double FloorsLength { get; } = 50.0;
        public static double WaitingAreaLength { get; } = 5.0;
        public static double HallLength { get; } = FloorsLength - WaitingAreaLength;
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
    }
}
