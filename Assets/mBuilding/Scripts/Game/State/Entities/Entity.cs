using R3;
using UnityEngine;

namespace mBuilding.Scripts.Game.State.Entities
{
    public abstract class Entity
    {
        public EntityData Origin { get; }
        public int UniqueId => Origin.UniqueId;
        public string ConfigId => Origin.ConfigId;
        public EntityType Type => Origin.Type;
        
        public readonly ReactiveProperty<Vector2Int> Position;

        public Entity(EntityData data)
        {
            Origin = data;

            Position = new ReactiveProperty<Vector2Int>(data.Position);
            Position.Subscribe(newPosition => { data.Position = newPosition; });
        }
    }
}