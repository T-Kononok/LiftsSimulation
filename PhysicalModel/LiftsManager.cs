using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalModel {
    class LiftsManager {

        public Dictionary<int, Queue<int>> _map;
        public List<Floor<HQueue>> _floors;

        public LiftsManager(int quantityFloors, List<Floor<HQueue>> floors) {
            _floors = floors;
            _map = new Dictionary<int, Queue<int>>(quantityFloors);
            for (var i = 0; i < quantityFloors; i++) {
                _map.Add(i, new Queue<int>());
            }
        }
    }
}
