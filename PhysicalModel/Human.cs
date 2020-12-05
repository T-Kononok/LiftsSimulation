using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Entities;
using static PhysicalModel.PhysicalContext;
using static PhysicalModel.AreasList;

namespace PhysicalModel {
    class Human : Entity {

        public enum ConditionsType {
            InStartingFloor,
            ToStand,
            InTargetFloor
        }

        public ConditionsType Conditions { get; set; } 
            = ConditionsType.InStartingFloor;

        private double _speed = 2.0;

        private int _startingFloor;
        private int _targetFloor;

        private int _travelTime = 0;
        //private int _witingTime = 0;
        private int _timeAfterArrival = 0;

        public delegate void WaitHandler(Human human);
        event WaitHandler Wait;

        public Human(HumanStartingData data, WaitHandler handler) :
            base(data.Name, EntityType.Human, AllLiftLength + FloorsLength * 0.9,
                data.StartingFloor * (FloorsHeight + SlabsHeight) - FloorsHeight + EntityDiameter*2) {
            _startingFloor = data.StartingFloor;
            _targetFloor = data.TargetFloor;
            Wait += handler;
        }

        public override bool RecalculateLocation() {
            _travelTime++;

            switch (Conditions) {
                case ConditionsType.InStartingFloor:
                    X -= _speed;
                    if (X < AllLiftLength + WaitingAreaLength) {
                        Conditions = ConditionsType.ToStand;
                        Wait(this);
                    }
                    return true;
                case ConditionsType.InTargetFloor:
                    _timeAfterArrival++;
                    X += _speed;
                    if (_timeAfterArrival >= 3)
                        return false;
                    return true;
                default:
                    return true;
            }
        }

        public override EntityLocation GetLocation() {
            return new EntityLocation(EntityType.Human, X, Y);
        }
    }
}
