using System.Collections.Generic;
using System.Linq;
using mBuilding.Scripts.Game.Settings;
// using mBuilding.Scripts.Game.State.Buildings;
using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Entities;
using mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings;
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
            foreach (var buildingSettings in newMapInitialStateSettings.Buildings)
            {
                var initialBuilding = new BuildingEntityData
                {
                    UniqueId = _gameState.CreateEntityId(),
                    ConfigId = buildingSettings.TypeId,
                    Type = EntityType.Building,
                    Position = buildingSettings.Position,
                    Level = buildingSettings.Level,
                    IsAutoCollectionEnabled = false,
                    LastClickedTimeMS = 0
                };
            
                initialEntities.Add(initialBuilding);
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