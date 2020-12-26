using Autofac;
using Entities;
using IModel;
using PhysicalModel;
using Services;

namespace Presentation.Autofac {
    public static class AutofacBuilder {
        public static IContainer Build() {

            var builder = new ContainerBuilder();

            builder.RegisterType<BeginingService>().As<IBegining>().SingleInstance();
            builder.RegisterType<ChangeLiftsStrategyService>().As<IChangeLiftsStrategy>().SingleInstance();
            builder.RegisterType<ChangePeopleStrategyService>().As<IChangePassengerStrategy>().SingleInstance();
            builder.RegisterType<ChangeSpeedService>().As<IChangeSpeed>().SingleInstance();
            builder.RegisterType<EndingService>().As<IEnding>().SingleInstance();
            builder.RegisterType<PassengerAddableService>().As<IPassengerAddable>().SingleInstance();
            builder.RegisterType<GivingMovableInfoService>().As<IGivingMovableInfo>().SingleInstance();
            builder.RegisterType<GivingXYChangedEventServise>().As<IGivingXYChangedEvent>().SingleInstance();

            builder.RegisterType<Floor>().As<IFloor>();
            builder.RegisterType<LiftsHall>().As<ILiftsHall>();
            builder.RegisterType<Shafts>().As<IShafts>().SingleInstance();
            builder.RegisterType<Passenger>().As<IPassenger>();
            builder.RegisterType<PassengerState1>().As<IPassengerState>();
            builder.RegisterType<Lift>().As<ILift>();

            builder.RegisterType<Building>().As<IBuilding>().SingleInstance();
            builder.RegisterType<ClockGenerator>().As<IClockGenerator>().SingleInstance();
            builder.RegisterType<ManagerLifts>().As<IManagerLifts>().SingleInstance();

            return builder.Build();
        }
    }
}
