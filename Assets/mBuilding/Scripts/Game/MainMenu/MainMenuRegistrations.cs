using BaCon;
using mBuilding.Scripts.Game.MainMenu.Root;
using mBuilding.Scripts.Game.MainMenu.Services;
using mBuilding.Scripts.Services;

namespace mBuilding.Scripts.Game.MainMenu
{
    public static class MainMenuRegistrations
    {
        public static void Register(DIContainer container, MainMenuEnterParams mainMenuEnterParams)
        {
            container.RegisterFactory(c => new SomeMainMenuService(c.Resolve<SomeCommonService>())).AsSingle();
        }
    }
}