using mBuilding.Scripts.Game.Settings.Gameplay.Entities;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingLevelSettings", menuName = "Game Settings/Entities/Buildings/New Building Level Settings")]
    public class BuildingLevelSettings : EntityLevelSettings
    {
        [field: SerializeField] public double BaseIncome { get; private set; }
    }
}