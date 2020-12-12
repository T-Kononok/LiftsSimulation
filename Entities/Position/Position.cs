﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public abstract class Position {

        public LocationPosition Location { get; }
        public double X { get; }
        public double Y { get; }

        protected Position(LocationPosition location, double x, double y) {
            Location = location;
            X = x;
            Y = y;
        }
    }
}