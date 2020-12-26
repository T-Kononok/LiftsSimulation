using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace PhysicalModel {
    public class ClockGenerator : IClockGenerator{

        private readonly Task _task;

        private bool _isWork = false;

        private bool _isPause = false;

        private int _time = 0;
        public int Time { get { return _time; } }

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
            _task = new Task(Work);
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

        private void Work() {
            while (_isWork) {
                while (_isPause) { }
                Task.Delay(GetPseudoSecond()).Wait();
                _time++;
                Clock();
            }
        }

        private int GetPseudoSecond() {
            return (int)Round(1000.0 * Сoefficient);
        }

    }
}
