﻿using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalModel {
    class Floor : IFloor {

        public Size Size { get; } = new Size(80.0, 3.5);

        public double X { get; set; }
        public double Y { get; set; }

        public int Number { get; }

        public ILiftsHall Hall { get; }

        private readonly LinkedList<IMovable> _movables = new LinkedList<IMovable>();

        public Floor(int number, double x, double y, ILiftsHall.Factory factory) {
            Number = number;
            X = x;
            Y = y;
            Hall = factory(this);
        }

        public Position GetPosition() {
            return new FloorPosition(X,Y);
        }

        public bool AddMovable(IMovable movable) {
            _movables.AddFirst(movable);
            return true;
        }
        public bool RemoveMovable(IMovable movable) {
            return _movables.Remove(movable);
        }

        public void GetClockHandler(IClockGenerator generator) {
            generator.SetClockHandler(ClockHandler);
        }

        private void ClockHandler() {
            var positions = new List<Position>(_movables.Count);
            Parallel.ForEach(_movables, HandleClock);
            PositionsChanged(GetPosition(), positions);

            void HandleClock(IMovable movable) {
                if (!movable.HandleClock())
                    return;
                positions.Add(movable.GetPosition());
            }
        }
        
        event Action<Position,List<Position>> PositionsChanged;
        public void SetPositionsChangedHandler(Action<Position, List<Position>> handler) {
            PositionsChanged += handler;
        }       
    }
}
