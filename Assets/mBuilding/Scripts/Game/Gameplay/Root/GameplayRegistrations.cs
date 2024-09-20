using BaCon;
using mBuilding.Scripts.Game.Gameplay.Commands;
using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Game.State;
using mBuilding.Scripts.Game.State.cmd;

namespace mBuilding.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            var gameStateProvider = container.Resolve<IGameStateProvider>();
            var gameState = gameStateProvider.GameState;
            
            var cmd = new CommandProcessor(gameStateProvider);
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameState));
            container.RegisterInstance<ICommandProcessor>(cmd);
            
            container.RegisterFactory(_ => new BuildingsService(gameState.Buildings, cmd)).AsSingle();
        }
    }
}