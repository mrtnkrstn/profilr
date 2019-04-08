using MvvmCross.ViewModels;
using Profilr.Core.ViewModels;

namespace Profilr.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<LandingViewModel>();
        }
    }
}
