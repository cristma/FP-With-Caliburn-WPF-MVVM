using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Segments
{
    public interface IRouteDetailsViewModel : IScreen
    {
        bool Exists { get; }
        void Load(Guid id);
    }
}
