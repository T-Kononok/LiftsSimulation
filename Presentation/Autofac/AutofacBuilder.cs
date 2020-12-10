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
            builder.RegisterType<ChangePeopleStrategyService>().As<IChangePeopleStrategy>().SingleInstance();
            builder.RegisterType<ChangeSpeedService>().As<IChangeSpeed>().SingleInstance();
            builder.RegisterType<EndingService>().As<IEnding>().SingleInstance();
            builder.RegisterType<EntityAddableService>().As<IEntityAddable>().SingleInstance();
            builder.RegisterType<GivingEntityInfoService>().As<IGivingEntityInfo>().SingleInstance();
            builder.RegisterType<GivingXYChangedEventServise>().As<IGivingXYChangedEvent>().SingleInstance();

            return builder.Build();
        }
    }
}
