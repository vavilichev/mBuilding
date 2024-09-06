using System;
using System.Collections.Generic;
using mBuilding.Scripts.Game.State.Buildings;

namespace mBuilding.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public List<BuildingEntity> Buildings;
    }
}