using System;
using IModel;
using Entities;
using Autofac;
using System.Collections.Generic;
using Services;
using System.Threading.Tasks;

namespace Presentation {
    class MainClass {
        static void Main(string[] args) {

            Console.WriteLine("-1");
            var container = Autofac.AutofacBuilder.Build();
            Console.WriteLine("0");

            using (var scope = container.BeginLifetimeScope()) {
                Console.WriteLine("1");
                var beginingSevise = scope.Resolve<IBegining>();
                Console.WriteLine("2");
                var liftList = new List<LiftStartingData>();
                var liftData = new LiftStartingData(3,2.0,1.0);
                liftList.Add(liftData);
                Console.WriteLine("3");
                beginingSevise.Begin(new BeginningConfiguration(5, liftList));
                var endingService = scope.Resolve<IEnding>();
                var changeSpeedService = scope.Resolve<IChangeSpeed>();
                changeSpeedService.Pause();

                var changedEventServise = scope.Resolve<IGivingXYChangedEvent>();
                changedEventServise.PositionsChanged += Handler;
                void Handler(Position areaPosition, List<Position> list) {
                    if (list.Count == 0)
                        return;
                    Console.WriteLine(areaPosition + " " + areaPosition.Y + " :");
                    foreach (Position position in list)
                        Console.WriteLine("    " + (position.X + areaPosition.X) 
                            + "/" + (position.Y + areaPosition.Y));
                }
                Console.WriteLine("Плей");
                changeSpeedService.Play();
                changeSpeedService.ChangeSpeed(0.1);

                var passengerAddableService = scope.Resolve<IPassengerAddable>();
                passengerAddableService.AddPassenger(
                    new PassengerStartingData("Ноунейм",3,1));

                Task.Delay(10000).Wait();
                endingService.End();
                Task.Delay(2000).Wait();
                Console.WriteLine("Конец!");
            }
        }
    }
}
