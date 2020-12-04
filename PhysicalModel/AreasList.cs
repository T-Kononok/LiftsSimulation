using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using static PhysicalModel.PhysicalContext;

namespace PhysicalModel {
    class AreasList {
        private List<WaitingArea> _areas = new List<WaitingArea>();

        public AreasList() {
            for (var i = 1; i <= QuantityFloors; i++) {
                _areas.Add(new WaitingArea(AllLiftLength, i * (FloorsHeight+SlabsHeight)));
            }
        }

        public void AddHuman(Human human) {
            _areas[GetAreaIndex(human.Y)].EnqueueEntity(human);
        }

        private int GetAreaIndex(double y) {
            return (int)(y / FloorsHeight) + 1;
        }

    }
}
