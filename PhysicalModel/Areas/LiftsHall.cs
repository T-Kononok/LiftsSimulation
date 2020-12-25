﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace PhysicalModel {
    class LiftsHall : ILiftsHall {
             
        public Size Size { get; }

        public double X { get; set; }
        public double Y { get; set; }
        public Position GetPosition() {
            return new LiftsHallPosition(X, Y);
        }

        public int Number { get; }

        private readonly LinkedList<IMovable> _movables = new LinkedList<IMovable>();      

        private LiftsHall(int number, IFloor floor) {
            Number = number;
            X = floor.X - Size.Length;
            Y = floor.Y;
            Size = new Size(20.0,floor.Size.Height);
        }       

        public bool AddMovable(IMovable movable) {
            _movables.AddFirst(movable);
            movable.Location = this;
            return true;
        }
        public bool RemoveMovable(IMovable movable) {
            return _movables.Remove(movable);
        }       

        private void ClockHandler() {
            var positions = new List<Position>(_movables.Count);
            foreach(IMovable movable in _movables) {
                if (!movable.HandleClock())
                    continue;
                positions.Add(movable.GetPosition());
            }
            PositionsChanged(GetPosition(), positions);
        }
        public void GetClockHandler(IClockGenerator generator) {
            generator.Clock += ClockHandler;
        }

        public event Action<Position,List<Position>> PositionsChanged;
    }
}
