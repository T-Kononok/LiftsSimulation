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

            _building.SetPositionsChangedHandlers(Handle);

            void Handle(Position position, List<Position> list) {
                Console.WriteLine(position + " : " + list.Count);
            }

            _generator.Start();
            Console.WriteLine(_generator.Time);
            Task.Delay(1000).Wait();
            Console.WriteLine(_generator.Time);
            Task.Delay(1000).Wait();
            _generator.Pause();
            Task.Delay(3000).Wait();
            _generator.Play();
            _generator.Сoefficient *= 0.5;
            Console.WriteLine(_generator.Time);
            Task.Delay(1000).Wait();
            Console.WriteLine(_generator.Time);
            Task.Delay(1000).Wait();
            Console.WriteLine(_generator.Time);
            Task.Delay(1000).Wait();
            Console.WriteLine(_generator.Time);
            Task.Delay(1000).Wait();

            _isCreate = true;
        }
    }
}
