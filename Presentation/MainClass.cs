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

            var container = Autofac.AutofacBuilder.Build();

            using (var scope = container.BeginLifetimeScope()) {
                var beginingSevise = scope.Resolve<IBegining>();

                var liftList = new List<LiftStartingData>();
                var liftData = new LiftStartingData(3,2.0,1.0);
                liftList.Add(liftData);
                liftList.Add(liftData);
                liftList.Add(liftData);
                liftList.Add(liftData);
                liftList.Add(liftData);
                beginingSevise.Begin(new BeginningConfiguration(5, liftList));

                var changedEventServise = scope.Resolve<IGivingXYChangedEvent>();
                changedEventServise.PositionsChanged += Handler;
                void Handler(Position areaPosition, List<Position> list) {
                    if (list.Count == 0)
                        return;
                    Console.WriteLine(areaPosition + " :");
                    foreach (Position position in list)
                        Console.WriteLine("    " + (position.X + areaPosition.X) 
                            + "/" + (position.Y + areaPosition.Y));
                }

                var changeSpeedService = scope.Resolve<IChangeSpeed>();
                var endingService = scope.Resolve<IEnding>();
                Console.WriteLine(changeSpeedService.GetTime());
                Task.Delay(1000).Wait();
                var passengerAddableService = scope.Resolve<IPassengerAddable>();
                passengerAddableService.AddPassenger(
                    new PassengerStartingData("Ноунейм",1,2));
                Task.Delay(1000).Wait();
                changeSpeedService.Pause();
                Console.WriteLine("Пауза");
                Task.Delay(2000).Wait();
                passengerAddableService.AddPassenger(
                    new PassengerStartingData("Вася", 3, 1));
                Task.Delay(1000).Wait();
                Console.WriteLine("Плей");
                changeSpeedService.Play();
                changeSpeedService.ChangeSpeed(0.2);
                passengerAddableService.AddPassenger(
                   new PassengerStartingData("Петя", 4, 1));
                passengerAddableService.AddPassenger(
                   new PassengerStartingData("Гоша", 2, 5));
                Task.Delay(2000).Wait();
                endingService.End();
                Task.Delay(2000).Wait();
                Console.WriteLine("Конец!");
            }
        }
    }
}
