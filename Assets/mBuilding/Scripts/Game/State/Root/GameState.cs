using System;
using System.Collections.Generic;
using mBuilding.Scripts.Game.State.Maps;

namespace mBuilding.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public int CurrentMapId;
        public List<MapState> Maps;

        public int CreateEntityId()
        {
            return GlobalEntityId++;
        }
    }
}