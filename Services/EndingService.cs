using System;
using IModel;
using PhysicalModel;

namespace Services {
    public class EndingService : IEnding {

        IClockGenerator _generator;

        public EndingService(IClockGenerator generator) {
            _generator = generator;
        }

        public bool End() {
            _generator.Stop();
            return true;
        }
    }
}
