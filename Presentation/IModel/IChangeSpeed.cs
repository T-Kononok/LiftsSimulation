using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.IModel {
    interface IChangeSpeed {
        public DateTime GetTime();
        public void Stop();
        public void Start();
        public void ChangeSpeed(float coefficient);

    }
}
