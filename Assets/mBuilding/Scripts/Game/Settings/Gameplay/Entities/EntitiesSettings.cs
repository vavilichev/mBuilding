using System.Collections.Generic;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "EntitiesSettings", menuName = "Game Settings/Entities/New Entities Settings")]
    public class EntitiesSettings : ScriptableObject
    {
        [field: SerializeField] public List<BuildingSettings> Buildings { get; private set; }
    }
}