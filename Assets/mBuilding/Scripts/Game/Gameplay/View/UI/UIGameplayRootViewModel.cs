using mBuilding.Scripts.MVVM.UI;

namespace mBuilding.Game.View.UI
{
    public class UIGameplayRootViewModel : UIRootViewModel
    {
        public readonly CheatPanelViewModel CheatPanelViewModel;

        public UIGameplayRootViewModel(CheatsService cheatsService)
        {
            CheatPanelViewModel = new CheatPanelViewModel(cheatsService);
        }
    }
}