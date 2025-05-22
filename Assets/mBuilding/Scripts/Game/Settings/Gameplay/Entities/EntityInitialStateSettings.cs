using System;
using mBuilding.Scripts.Game.State.Entities;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [Serializable]
    public class EntityInitialStateSettings
    {
        [field: SerializeField] public EntityType EntityType { get; private set; }
        [field: SerializeField] public string ConfigId { get; private set; }
        [field: SerializeField] public int Level { get; private set; }
        [field: SerializeField] public Vector2Int InitialPosition { get; private set; }
    }
}