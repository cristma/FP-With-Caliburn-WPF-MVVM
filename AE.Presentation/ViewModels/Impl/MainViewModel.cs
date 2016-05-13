using AE.Presentation.ViewModels.Approaches;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Impl
{
    public class MainViewModel : Screen, IMainViewModel
    {
        private readonly IApproachCollectionViewModel approachCollectionViewModel;

        public MainViewModel(
            IApproachCollectionViewModel approachCollectionViewModel)
        {
            if (approachCollectionViewModel == null)
                throw new ArgumentNullException("approachCollectionViewModel");

            this.approachCollectionViewModel = approachCollectionViewModel;
            this.approachCollectionViewModel.ConductWith(this);
            this.DisplayName = "Instrument Procedure Approach Development Tool";
        }

        public IApproachCollectionViewModel ApproachCollectionControl { get { return this.approachCollectionViewModel; } }
    }
}
