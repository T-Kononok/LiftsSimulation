using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PhysicalModel {
    public interface IManagerLifts {

        public void AddHall(ILiftsHall hall);

        public void AddLift(ILift lift);

        public void BuildMap();

        public void LiftCallingHandler(int floorNumber, int targetFloor);

        public void HandleClock();
    }
}
