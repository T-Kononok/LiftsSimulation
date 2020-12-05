using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface IHQueue : IArea {
        public static double Length { get; } = 5.0;

        public static int MaxCount { get; } = (int)(Length / (1.5 * IEntity.Diameter));

        public void SetManager(LiftsManager manager);
    }
}
