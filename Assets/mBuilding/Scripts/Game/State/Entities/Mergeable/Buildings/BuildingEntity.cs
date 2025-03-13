using R3;

namespace mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings
{
    public class BuildingEntity : MergeableEntity
    {
        public readonly ReactiveProperty<double> LastClickedTimeMs;
        public readonly ReactiveProperty<bool> IsAutoCollectionEnabled;
        
        public BuildingEntity(BuildingEntityData data) : base(data)
        {
            LastClickedTimeMs = new ReactiveProperty<double>(data.LastClickedTimeMS);
            LastClickedTimeMs.Subscribe(newLastClickedTime => data.LastClickedTimeMS = newLastClickedTime);

            IsAutoCollectionEnabled = new ReactiveProperty<bool>(data.IsAutoCollectionEnabled);
            IsAutoCollectionEnabled.Subscribe(newValue => data.IsAutoCollectionEnabled = newValue);
        }
    }
}