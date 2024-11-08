using System.Collections.Generic;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingsSettings", menuName = "Game Settings/Buildings/New Buildings Settings")]
    public class BuildingsSettings : ScriptableObject
    {
        public List<BuildingSettings> AllBuildings;
    }
}