using Entities;

namespace IModel {
    public interface IBegining {
        void Begin(BeginningConfiguration configuration);

        public bool IsCreate { get; }
    }
}
