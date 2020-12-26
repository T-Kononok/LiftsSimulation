using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    public interface IClockGenerator {

        double Сoefficient { get; set; }

        DateTime Time { get; }

        public event Action Clock;

        void Start();
        void Stop();

        void Pause();
        void Play();
    }
}
