using mBuilding.Game;
using mBuilding.Game.View.UI;
using mBuilding.Scripts.MVVM.UI;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.Root.View
{
    public class UIGameplayRootBinder : UIRootBinder
    {
        [SerializeField] private CheatPanelBinder _binderCheatsPanel;
        // Если захотим что-то свое, то оверайдим OnBind
        
        protected override void OnBind(UIRootViewModel rootViewModel)
        {
            base.OnBind(rootViewModel);

            var viewModel = rootViewModel as UIGameplayRootViewModel;
            
            _binderCheatsPanel.Bind(viewModel.CheatPanelViewModel);
        }
    }
}
