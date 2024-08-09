using mBuilding.Scripts.Game.Gameplay.Services;

namespace mBuilding.Scripts.Game.Gameplay.Root.View
{
    public class UIGameplayRootViewModel
    {
        private readonly SomeGameplayService _someGameplayService;

        public UIGameplayRootViewModel(SomeGameplayService someGameplayService)
        {
            _someGameplayService = someGameplayService;
        }
    }
}