using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace PhysicalModel.Others {
    class ClockGenerator : IClockGenerator{

        private readonly Task _task;

        private bool _isWork = false;

        private bool _isPause = false;

        public DateTime Time { get; } = new DateTime();

        private double _coefficient = 1.0;
        public double Сoefficient {
            get {
                return _coefficient;
            }
            set {
                if (value < 0.001)
                    value = 0.001;
                _coefficient = value;
            }
        }

        public event Action Clock;

        public ClockGenerator() {
            _task = new Task(Action);
        }

        public void Start() {
            _task.Start();
            _isWork = true;
        }

        public void Stop() {
            _isWork = false;
            _isPause = false;
        }

        public void Pause() => _isPause = true;

        public void Play() => _isPause = false;

        private void Action() {
            while (_isWork) {
                while (_isPause) { }
                Task.Delay(GetPseudoSecond()).Wait();
                Time.AddSeconds(1);
                Clock();
            }
        }

        private int GetPseudoSecond() {
            return (int)Round(1000.0 * Сoefficient);
        }

    }
}
