using System;
using System.Threading.Tasks;
using static System.Math;

namespace PhysicalModel {
    class ClockGenerator {

        readonly Task _task;

        bool _isWork = false;

        bool _isPause = false;

        DateTime Time { get; } = new DateTime();

        double _coefficient = 1.0;
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

        public delegate void ClockHandler();
        event ClockHandler Clock;

        public void SetClockHandler(ClockHandler handler) {
            Clock += handler;
        }

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

        void Action() {
            while (_isWork) {
                while (_isPause) { }
                Task.Delay(GetPseudoSecond()).Wait();
                Time.AddSeconds(1);
                Clock();
            }
        }

        int GetPseudoSecond() {
            return (int)Round(1000.0 * Сoefficient);
        }
    }
}
