using System;

namespace IModel {
    public interface IChangeSpeed {
        int GetTime();
        void Pause();
        void Play();
        void ChangeSpeed(double coefficient);
    }
}
