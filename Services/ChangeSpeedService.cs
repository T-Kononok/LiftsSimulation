using System;
using IModel;
using PhysicalModel;

namespace Services {
    public class ChangeSpeedService : IChangeSpeed {

        IClockGenerator _generator;

        public ChangeSpeedService(IClockGenerator generator) {
            _generator = generator;
        }

        public void ChangeSpeed(double coefficient) {
            _generator.Сoefficient = coefficient;
        }

        public int GetTime() {
            return _generator.Time;
        }

        public void Pause() {
            _generator.Pause();
        }

        public void Play() {
            _generator.Play();
        }
    }
}
