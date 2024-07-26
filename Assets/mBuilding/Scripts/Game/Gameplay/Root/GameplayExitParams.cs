using mBuilding.Scripts.Game.MainMenu.Root;

namespace mBuilding.Scripts.Game.Gameplay.Root
{
    public class GameplayExitParams
    {
        public  MainMenuEnterParams MainMenuEnterParams { get; }

        public GameplayExitParams(MainMenuEnterParams mainMenuEnterParams)
        {
            MainMenuEnterParams = mainMenuEnterParams;
        }
    }
}