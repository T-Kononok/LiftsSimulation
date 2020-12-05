using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface IFloor : IArea {
        public static double Length { get; } = 50.0;
        public static double Height { get; } = 3.5;

        public static int Quantity { get; set; }
    }
}
