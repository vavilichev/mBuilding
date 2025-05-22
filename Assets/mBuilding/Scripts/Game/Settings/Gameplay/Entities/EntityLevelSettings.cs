using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Entities
{
    [CreateAssetMenu(fileName = "EntityLevelSettings", menuName = "Game Settings/Entities/New Entity Level Settings")]
    public class EntityLevelSettings : ScriptableObject
    {
        [field: SerializeField] public int Level { get; private set; }
        [field: SerializeField] public string PrefabSkinPath { get; private set; }
    }
}