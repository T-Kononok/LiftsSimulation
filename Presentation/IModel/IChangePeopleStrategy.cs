
namespace Presentation.IModel {
    public interface IChangePeopleStrategy {
        void ChangePeopleStrategy(PeopleStrategies strategy);
    }

    public enum PeopleStrategies {
        Fire,
        Work
    }
}
