using mBuilding.Scripts.Game.Settings.Gameplay.Entities;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingSettings", menuName = "Game Settings/Buildings/New Building Settings")]
    public class BuildingSettings : EntitySettings<BuildingLevelSettings>
    {
    }
}