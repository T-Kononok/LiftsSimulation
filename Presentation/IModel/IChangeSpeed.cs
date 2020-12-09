using System;

namespace Presentation.IModel {
    public interface IChangeSpeed {
        DateTime GetTime();
        void Pause();
        void Play();
        void ChangeSpeed(double coefficient);
    }
}
