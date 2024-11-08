using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingLevelSettings", menuName = "Game Settings/Buildings/New Building Level Settings")]
    public class BuildingLevelSettings : ScriptableObject
    {
        public int Level;
        public double BaseIncome;
    }
}