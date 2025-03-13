using System.Collections.Generic;
using mBuilding.Scripts.Game.State.Entities;

namespace mBuilding.Scripts.Game.State.Maps
{
    public class MapData
    {
        public int Id { get; set; }
        public List<EntityData> Entities { get; set; }
    }
}