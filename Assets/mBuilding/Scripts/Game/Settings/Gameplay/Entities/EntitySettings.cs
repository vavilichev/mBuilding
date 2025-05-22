using System.Collections.Generic;
using mBuilding.Scripts.Game.State.Entities;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Entities
{
    public abstract class EntitySettings<T> : ScriptableObject where T : EntityLevelSettings
    {
        [field: SerializeField] public EntityType EntityType { get; private set; }
        [field: SerializeField] public string ConfigId { get; private set; }
        [field: SerializeField] public string TitleLid { get; private set; }
        [field: SerializeField] public string DescriptionLid { get; private set; }
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public List<T> Levels { get; private set; }
    }
    
    [CreateAssetMenu(fileName = "EntitySettings", menuName = "Game Settings/Entities/New Entity Settings")]
    public class EntitySettings : EntitySettings<EntityLevelSettings>
    {

    }
}