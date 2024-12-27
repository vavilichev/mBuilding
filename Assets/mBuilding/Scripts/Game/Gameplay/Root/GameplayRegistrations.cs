using System;
using System.Linq;
using BaCon;
using mBuilding.Scripts.Game.Common;
using mBuilding.Scripts.Game.Gameplay.Commands;
using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Game.Settings;
using mBuilding.Scripts.Game.State;
using mBuilding.Scripts.Game.State.cmd;
using R3;

namespace mBuilding.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            var gameStateProvider = container.Resolve<IGameStateProvider>();
            var gameState = gameStateProvider.GameState;
            var settingsProvider = container.Resolve<ISettingsProvider>();
            var gameSettings = settingsProvider.GameSettings;
            
            container.RegisterInstance(AppConstants.EXIT_SCENE_REQUEST_TAG, new Subject<Unit>());

            var cmd = new CommandProcessor(gameStateProvider);
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameState));
            cmd.RegisterHandler(new CmdCreateMapStateHandler(gameState, gameSettings));
            cmd.RegisterHandler(new CmdResourcesAddHandler(gameState));
            cmd.RegisterHandler(new CmdResourcesSpendHandler(gameState));
            container.RegisterInstance<ICommandProcessor>(cmd);
            
            // На данный момент мы знаем, что мы пытаемся загрузить карту. Но не знаем, есть ли ее состояние вообще.
            // Создание карты - это модель, так что работать с ней нужно через команды, поэтому нужен обработчик команд
            // на случай, если состояния карты еще не суествует. Может мы этот момент передалаем потом, чтобы 
            // состояние карты создавалось ДО загрузки сцены и тут не было подобных проверок, но пока так. Делаем пошагово
            var loadingMapId = gameplayEnterParams.MapId;
            var loadingMap = gameState.Maps.FirstOrDefault(m => m.Id == loadingMapId);
            if (loadingMap == null)
            {
                // Создание состояния, если его еще нет через команду.
                var command = new CmdCreateMapState(loadingMapId);
                var success = cmd.Process(command);
                if (!success)
                {
                    throw new Exception($"Couldn't create map state with id: ${loadingMapId}");
                }

                loadingMap = gameState.Maps.First(m => m.Id == loadingMapId);
            }

            container.RegisterFactory(_ => new BuildingsService(
                loadingMap.Buildings,
                gameSettings.BuildingsSettings,
                cmd)
            ).AsSingle();

            container.RegisterFactory(_ => new ResourcesService(gameState.Resources, cmd)).AsSingle();
        }
    }
}