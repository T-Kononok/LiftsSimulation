using System;
using IModel;
using Entities;
using Autofac;
using System.Collections.Generic;

namespace Presentation {
    class MainClass {
        static void Main(string[] args) {

            var container = Autofac.AutofacBuilder.Build();

            using (var scope = container.BeginLifetimeScope()) {
                var beginingSevise = scope.Resolve<IBegining>();
                var liftData = new LiftStartingData(5,2.0,1.0);
                var liftList = new List<LiftStartingData>();
                liftList.Add(liftData);
                beginingSevise.Begin(new BeginningConfiguration(5, liftList));
            }
        }
    }
}
