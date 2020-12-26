
namespace IModel {
    public interface IChangePassengerStrategy {
        void ChangePeopleStrategy(PassengerStrategies strategy);
    }

    public enum PassengerStrategies {
        Fire,
        Work
    }
}
