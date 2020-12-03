using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.IModel {
    interface IChangeSpeed {
        DateTime GetTime();
        void Pause();
        void Play();
        void ChangeSpeed(double coefficient);
    }
}
