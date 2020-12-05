using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel.Interfaces {
    interface IClockGenerator {

        public double Сoefficient { get; set; }

        public DateTime Time { get; }

        public delegate void ClockHandler();
        public void SetClockHandler(ClockHandler handler);

        public void Start();
        public void Stop();

        public void Pause();
        public void Play();



    }
}
