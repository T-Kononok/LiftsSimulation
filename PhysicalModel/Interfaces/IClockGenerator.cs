using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface IClockGenerator {

        double Сoefficient { get; set; }

        DateTime Time { get; }

        delegate void ClockHandler();
        void SetClockHandler(ClockHandler handler);

        void Start();
        void Stop();

        void Pause();
        void Play();
    }
}
