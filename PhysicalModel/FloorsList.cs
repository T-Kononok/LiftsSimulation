using System;
using System.Collections.Generic;
using System.Text;
using PhysicalModel.Interfaces;
using Presentation.Entities;

namespace PhysicalModel {
    class FloorsList {

        private readonly List<Floor<HQueue>> _floors = new List<Floor<HQueue>>();

        private Shafts _shafts;
        private LiftsManager _manager;


        public FloorsList(IClockGenerator generator, int quantityFloors, int quantityLifts) {
            IFloor.Quantity = quantityFloors;
            _manager = new LiftsManager(quantityFloors, _floors);
            _shafts = new Shafts(quantityLifts, generator);
            _shafts.SetLocationsChangedHandler(LocationsChangedHandler);
            _shafts.SetManager(_manager);
            for (var i = 0; i < quantityFloors; i++) {
                var floor = new Floor<HQueue>(_shafts.Length, i * IFloor.Height, generator);
                floor.SetLocationsChangedHandler(LocationsChangedHandler);
                _floors.Add(floor);
            }
        }

        void LocationsChangedHandler(EntityLocation source, LinkedList<EntityLocation> locations) {
            // в сервис а потом в виев
        }
    }
}
