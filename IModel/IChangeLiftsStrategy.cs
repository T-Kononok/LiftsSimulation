
namespace IModel {
    public interface IChangeLiftsStrategy {
        void ChangeLiftsStrategy(LiftsStrategies strategy);
    }

    public enum LiftsStrategies {
        Fire,
        MinTimeout,
        MinIdling,
        MinDeliveryTime
    }
}
