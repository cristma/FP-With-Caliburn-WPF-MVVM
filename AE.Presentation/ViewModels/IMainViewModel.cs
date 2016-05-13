using AE.Presentation.ViewModels.Approaches;
using Caliburn.Micro;

namespace AE.Presentation.ViewModels
{
    public interface IMainViewModel : IScreen
    {
        IApproachCollectionViewModel ApproachCollectionControl { get; }
    }
}
