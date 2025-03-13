namespace mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings
{
    public class BuildingEntityData : MergeableEntityData
    {
        public double LastClickedTimeMS { get; set; }       // Время последнего клика по зданию, чтобы собрать ресурс
        public bool IsAutoCollectionEnabled { get; set; }   // Возможность прокачать автосбор ресурсов (не надо кликать)
    }
}