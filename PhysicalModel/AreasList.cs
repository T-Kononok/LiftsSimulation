using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using static PhysicalModel.PhysicalContext;
using PhysicalModel.Interfaces;

namespace PhysicalModel {
    class AreasList : IAreaList {

        public static double FloorsHeight { get; } = 3.0;
        public static int QuantityFloors { get; private set; }
        public static int QuantityLifts { get; private set; }

        private List<WaitingArea> _areas = new List<WaitingArea>();

        public AreasList(int quantityFloors, int quantityLifts) {
            QuantityFloors = quantityFloors;
            QuantityLifts = quantityLifts;
            for (var i = 0; i < QuantityFloors; i++) {
                _areas.Add(new WaitingArea(AllLiftLength));
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
