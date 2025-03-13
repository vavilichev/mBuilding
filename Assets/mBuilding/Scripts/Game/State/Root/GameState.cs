using System.Collections.Generic;
using mBuilding.Scripts.Game.State.GameResources;
using mBuilding.Scripts.Game.State.Maps;

namespace mBuilding.Scripts.Game.State.Root
{
    public class GameState
    {
        public int GlobalEntityId { get; set; }
        public int CurrentMapId { get; set; }
        public List<MapData> Maps { get; set; }
        public List<ResourceData> Resources { get; set; }

        public int CreateEntityId()
        {
            return GlobalEntityId++;
        }
    }
}