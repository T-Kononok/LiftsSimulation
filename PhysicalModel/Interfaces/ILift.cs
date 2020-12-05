using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface ILift : IArea, IEntity {
        public static int Capacity { get; } = 1;
        public static double Length { get; } = Capacity * IEntity.Diameter * 1.5;

        public void SetManager(LiftsManager manager);

    }
}
