using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace PhysicalModel {
    public class ManagerLifts : IManagerLifts {

        private List<ILift> _lifts = new List<ILift>();

        private List<ILiftsHall> _halls = new List<ILiftsHall>();

        private Dictionary<int, double> _floorYMap = new Dictionary<int, double>();

        private Dictionary<double, int> _YFloorMap = new Dictionary<double, int>();

        private List<List<int>> _matrix;

        private Dictionary<double, int> _passengersMap = new Dictionary<double, int>();

        private Dictionary<ILift, LinkedList<double>> _targetsMap =
            new Dictionary<ILift, LinkedList<double>>();


        public void AddHall(ILiftsHall hall) {
            _halls.Add(hall);
        }

        public void AddLift(ILift lift) {
            _lifts.Add(lift);
            _passengersMap.Add(lift.X, 0);
            _targetsMap.Add(lift, new LinkedList<double>());
        }

        public void BuildMap() {
            _matrix = new List<List<int>>();
            for (var i = 0; i < _halls.Count; i++) {
                _matrix.Add(new List<int>(_halls.Count));
                _floorYMap.Add(i, _halls[i].Y);
                _YFloorMap.Add(_halls[i].Y, i);
            }
        }

        public void LiftCallingHandler(int floorNumber, int targetFloor) {
            _matrix[floorNumber+1][targetFloor+1]++;
        }

        public void HandleClock() {
            foreach (ILift lift in _lifts) {
                if (lift.NeedMoveTo == 0.0) {
                    if (_targetsMap[lift].Count == 0) {
                        _targetsMap[lift] = ArrivedСhoice(lift);
                    }
                    if (_targetsMap[lift].Count != 0) {
                        lift.NeedMoveTo = Abs(lift.Y - _targetsMap[lift].First.Value);
                        lift.Direction = Sign(lift.Y - _targetsMap[lift].First.Value);
                        _targetsMap[lift].RemoveFirst();
                    }
                }
            }
        }

        private LinkedList<double> ArrivedСhoice(ILift lift) {
            var maxBenefits = 0.0;
            var maxTargetList = new LinkedList<double>();
            maxTargetList.AddLast(lift.Y);

            Parallel.For(0,_matrix.Count, CalculationColumn);
            
            void CalculationColumn(int j) {
                for (var i = 0; i < _matrix.Count; i++) {
                    if (i == j)
                        continue;
                    var targetList = new LinkedList<double>();
                    var count = 0;
                    var inc = Sign(j - i);
                    for (var k = i; k != j; k += inc) {
                        count += _matrix[k][j];
                        targetList.AddLast(_floorYMap[k]);
                    }
                    var way = Abs(lift.Y - _floorYMap[i]) +
                        + Abs(_floorYMap[i] - _floorYMap[j]);

                    if (count / way > maxBenefits) {
                        maxBenefits = count / way;
                        maxTargetList = targetList;
                    }
                }
            }

            return maxTargetList;
        }     
    }
}
