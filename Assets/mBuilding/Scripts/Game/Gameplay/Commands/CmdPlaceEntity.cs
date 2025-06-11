using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Entities;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdPlaceEntity : ICommand
    {
        public readonly EntityType EntityType;
        public readonly string EntityConfigId;
        public readonly int Level;
        public readonly Vector2Int Position;
        
        public CmdPlaceEntity(EntityType entityType, string entityConfigId, int level, Vector2Int position)
        {
            EntityType = entityType;
            EntityConfigId = entityConfigId;
            Level = level;
            Position = position;
        }
    }
}