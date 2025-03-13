using System.Linq;
using mBuilding.Scripts.Game.State.Entities;
using ObservableCollections;
using R3;

namespace mBuilding.Scripts.Game.State.Maps
{
    public class Map
    {
        public int Id => Origin.Id;
        public ObservableList<Entity> Entities { get; } = new();
        public MapData Origin { get; }

        public Map(MapData mapData)
        {
            Origin = mapData;
            mapData.Entities.ForEach(entityData => Entities.Add(EntitiesFactory.CreateEntity(entityData)));
            
            Entities.ObserveAdd().Subscribe(e =>
            {
                var addedEntity = e.Value;
                mapData.Entities.Add(addedEntity.Origin);
            });
            
            Entities.ObserveRemove().Subscribe(e =>
            {
                var removedEntity = e.Value;
                var removedEntityData = mapData.Entities.FirstOrDefault(b => b.UniqueId == removedEntity.UniqueId);
                mapData.Entities.Remove(removedEntityData);
            });
        }
    }
}