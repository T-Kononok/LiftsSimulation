using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;
using static PhysicalModel.PhysicalContext;

namespace PhysicalModel {
    class Human : Entity {

        public static double _speed = 2.0;
        public static double Speed {
            get {
                return _speed;
            }
            set {
                if (value <= 0.01)
                    value = 0.01;
                _speed = value;
            }
        }

        public int StartingFloor { get; }
        public int TargetFloor { get; }

        private static int _travelTime = 0;
        public static int TravelTime { get { return _travelTime; } }

        private static int _witingTime = 0;
        public static int WaitingTime { get { return _witingTime; } }

        public bool IsDelivered { get; } = false;

        public Human(HumanStartingData data) :
            base(data.Name, EntityType.Human, FloorsLength * 0.9, data.StartingFloor * FloorsHeight) {
            StartingFloor = data.StartingFloor;
            TargetFloor = data.TargetFloor;
        }

        public override void RecalculateLocation() {
            if (X > 0) {
                X -= Speed;
            }
        }

        public override EntityLocation GetLocation() {
            return new EntityLocation(EntityType.Human, X, Y);
        }
    }
}
