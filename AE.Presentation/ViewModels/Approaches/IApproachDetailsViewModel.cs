using AE.Common;
using Caliburn.Micro;
using System;

namespace AE.Presentation.ViewModels.Approaches
{
    public interface IApproachDetailsViewModel : IScreen
    {
        Guid Id { get; }
        string ApproachName { get; }
        CriteriaType Criteria { get; }
        void Load(Guid id, string name, CriteriaType criteria);
    }
}