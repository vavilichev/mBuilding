using System.Linq;
using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Entities;
using mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings;
using mBuilding.Scripts.Game.State.Root;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdPlaceEntityHandler : ICommandHandler<CmdPlaceEntity>
    {
        private readonly GameStateProxy _gameState;

        public CmdPlaceEntityHandler(GameStateProxy gameState)
        {
            _gameState = gameState;
        }
        
        public bool Handle(CmdPlaceEntity command)
        {
            var currentMap = _gameState.Maps.FirstOrDefault(m => m.Id == _gameState.CurrentMapId.CurrentValue);
            if (currentMap == null)
            {
                Debug.LogError($"Couldn't find MapState for id: {_gameState.CurrentMapId.CurrentValue}");
                return false;
            }

            var entityConfigId = command.EntityConfigId;
            var entityType = command.EntityType;
            var entityLevel = command.Level;
            var entityPosition = command.Position;
            var entityId = _gameState.CreateEntityId();
            var createdEntityData = entityType switch
            {
                EntityType.Building => EntitiesDataFactory.CreateEntity<BuildingEntityData>(entityType, entityConfigId,
                    entityLevel, entityPosition),
                _ => throw new System.NotImplementedException(),
            };
            
            var createEntity = EntitiesFactory.CreateEntity(createdEntityData);
            
            currentMap.Entities.Add(createEntity);

            return true;
        }
    }
}