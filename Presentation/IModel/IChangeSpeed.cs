using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.IModel {
    interface IChangeSpeed {
        DateTime GetTime();
        void Stop();
        void Start();
        void ChangeSpeed(float coefficient);

    }
}
