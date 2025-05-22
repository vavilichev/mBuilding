using System;
using System.Collections.Generic;
using mBuilding.Scripts.Game.Settings.Gameplay.Buildings;
using UnityEngine.Serialization;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Maps
{
    [Serializable]
    public class MapInitialStateSettings
    {
        public List<EntityInitialStateSettings> Entities;
    }
}