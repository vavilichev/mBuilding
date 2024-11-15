using System;
using System.Collections.Generic;
using mBuilding.Scripts.Game.State.Buildings;

namespace mBuilding.Scripts.Game.State.Maps
{
    [Serializable]
    public class MapState
    {
        public int Id;
        public List<BuildingEntity> Buildings;
    }
}