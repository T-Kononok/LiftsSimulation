using System;
using IModel;
using Entities;
using PhysicalModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services {
    public class BeginingService : IBegining {

        private IBuilding _building;

        private IFloor.Factory _floorFactory;
        private ILiftsHall.Factory _hallFactory;
        private IShafts.Factory _shaftsFactory;      

        private IClockGenerator _generator;
        private IManagerLifts _manager;

        private bool _isCreate = false;
        public bool IsCreate { get { return _isCreate; } }

        public BeginingService(IBuilding building,
            IClockGenerator generator, IManagerLifts manager,
            IFloor.Factory floorFactory, ILiftsHall.Factory hallFactory,
            IShafts.Factory shaftsFactory) {

            _building = building;

            _floorFactory = floorFactory;
            _hallFactory = hallFactory;
            _shaftsFactory = shaftsFactory;

            _generator = generator;
            _manager = manager;
        }

        public void Begin(BeginningConfiguration data) {

            var lifts = new List<ILift>();
            foreach (LiftStartingData liftData in data.Lifts) {
                lifts.Add(new Lift(liftData, 1.0));
            }
            _building.SetFloors(data.QuantityFloors,
                _floorFactory, _hallFactory);
            _building.SetLifts(lifts, _shaftsFactory);
            _building.SetGenerator(_generator);
            _building.SetManager(_manager);
            _isCreate = true;

            _generator.Start();
        }
    }
}
