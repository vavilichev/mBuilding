using System;
using System.Collections.Generic;
using mBuilding.Scripts.Game.State.GameResources;
using mBuilding.Scripts.Game.State.Maps;

namespace mBuilding.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public int CurrentMapId;
        public List<MapState> Maps;
        public List<ResourceData> Resources;

        public int CreateEntityId()
        {
            return GlobalEntityId++;
        }
    }
}