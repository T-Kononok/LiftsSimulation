using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.IModel {
    interface IChangePeopleStrategy {
        public void ChangePeopleStrategy(PeopleStrategies strategy);
    }

    public enum PeopleStrategies {
        Fire,
        Work
    }
}
