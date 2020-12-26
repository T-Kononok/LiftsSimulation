using Autofac;
using Entities;
using IModel;
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

            return builder.Build();
        }
    }
}
