using System.Collections.Generic;
using System.Linq;
using mBuilding.Scripts.Game.Settings;
using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Entities;
using mBuilding.Scripts.Game.State.Maps;
using mBuilding.Scripts.Game.State.Root;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdCreateMapHandler : ICommandHandler<CmdCreateMap>
    {
        private readonly GameStateProxy _gameState;
        private readonly GameSettings _gameSettings;

        public CmdCreateMapHandler(GameStateProxy gameState, GameSettings gameSettings)
        {
            _gameState = gameState;
            _gameSettings = gameSettings;
        }

        public bool Handle(CmdCreateMap command)
        {
            var isMapAlreadyExisted = _gameState.Maps.Any(m => m.Id == command.MapId);

            if (isMapAlreadyExisted)
            {
                Debug.LogError($"Map with Id = {command.MapId} already exists");
                return false;
            }

            var newMapSettings = _gameSettings.MapsSettings.Maps.First(m => m.MapId == command.MapId);
            var newMapInitialStateSettings = newMapSettings.InitialStateSettings;

            var initialEntities = new List<EntityData>();
            foreach (var entitySettings in newMapInitialStateSettings.Entities)
            {
                var initialEntityData = EntitiesDataFactory.CreateEntity(entitySettings);
                initialEntityData.UniqueId = _gameState.CreateEntityId();
                initialEntities.Add(initialEntityData);
            }

            var newMapState = new MapData
            {
                Id = command.MapId,
                Entities = initialEntities
            };

            var newMapStateProxy = new Map(newMapState);

            _gameState.Maps.Add(newMapStateProxy);

            return true;
        }
    }
}