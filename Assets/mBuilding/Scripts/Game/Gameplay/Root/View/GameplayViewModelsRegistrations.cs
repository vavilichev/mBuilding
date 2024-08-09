using BaCon;
using mBuilding.Scripts.Game.Gameplay.Services;

namespace mBuilding.Scripts.Game.Gameplay.Root.View
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIGameplayRootViewModel(c.Resolve<SomeGameplayService>())).AsSingle();
            container.RegisterFactory(c => new WorldGameplayRootViewModel()).AsSingle();
        }
    }
}