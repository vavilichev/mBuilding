using System.Collections.Generic;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingSettings", menuName = "Game Settings/Buildings/New Building Settings")]
    public class BuildingSettings : ScriptableObject
    {
        public string TypeId;
        public string TitleLID;
        public string DescriptionLID;
        public List<BuildingLevelSettings> LevelsSettings;
    }
}