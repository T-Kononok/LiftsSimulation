using System;
using IModel;
using Entities;
using Autofac;

namespace Presentation {
    class MainClass {
        static void Main(string[] args) {

            var container = Autofac.AutofacBuilder.Build();

            using (var scope = container.BeginLifetimeScope()) {
                var beginingSevise = scope.Resolve<IBegining>();
                //beginingSevise.Begin(new BeginningConfiguration(5, 1));
            }
        }
    }
}
