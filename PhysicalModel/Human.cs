using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;

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

        public Human(HumanStartingData data) :
            base(data.Name, EntityType.Human, 90, data.StartingFloor * 50) {
        }

        public override void RecalculateLocation() {
            if (X > 0) {
                X -= 2.0;
            }
        }

        public override EntityLocation GetLocation() {
            return new EntityLocation(EntityType.Human, X, Y);
        }
    }
}
