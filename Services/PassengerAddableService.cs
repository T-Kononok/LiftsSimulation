using System;
using IModel;
using Entities;
using PhysicalModel;

namespace Services {
    public class PassengerAddableService : IPassengerAddable {

        private IBuilding _building;

        public PassengerAddableService(IBuilding building) {
            _building = building;
        }

        public bool AddPassenger(PassengerStartingData data) {
            _building.AddPassenger(new Passenger(data, new PassengerState1()));
            return true;
        }
    }
}
