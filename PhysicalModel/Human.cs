using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;
using PhysicalModel.Interfaces;

namespace PhysicalModel {
    class Human : Entity, IHuman {

        public String Name { get; } 

        private readonly double _speed = 2.0;

        private readonly int _startingFloor;
        public int TargetFloor { get; }

        private int _travelTime = 0;
        private int _witingTime = 0;
        private int _timeAfterArrival = 0;

        public bool IsArrival { get; set; } = false;

        public Human(HumanStartingData data) :
            base(EntityType.Human, IFloor.Length * 0.9, 2 * IEntity.Diameter) {
            Name = data.Name;
            _startingFloor = data.StartingFloor;
            _targetFloor = data.TargetFloor;
        }

        public override bool RecalculateLocation() {
            _travelTime++;

            switch (Source) {
                case IFloor _:
                    var speed = _speed;
                    if (IsArrival) {
                        speed *= -1;
                        _timeAfterArrival++;
                        if (_timeAfterArrival > 2)
                            return false;
                    }
                    X -= speed;
                    return true;
                case IHQueue _:
                    _witingTime++;
                    return true;
                case ILift _:
                    return true;
                default:
                    return true;
            }
        }

        public override EntityLocation GetLocation() {
            return new EntityLocation(EntityType.Human, Source.XAr + X, Source.YAr + Y);
        }
    }
}
