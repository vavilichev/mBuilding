using System.Linq;
using mBuilding.Scripts.Game.State.Buildings;
using ObservableCollections;
using R3;

namespace mBuilding.Scripts.Game.State.Maps
{
    public class Map
    {
        public int Id => Origin.Id;
        public ObservableList<BuildingEntityProxy> Buildings { get; } = new();
        public MapState Origin { get; }

        public Map(MapState mapState)
        {
            Origin = mapState;
            mapState.Buildings.ForEach(buildingOrigin => Buildings.Add(new BuildingEntityProxy(buildingOrigin)));
            
            Buildings.ObserveAdd().Subscribe(e =>
            {
                var addedBuildingEntity = e.Value;
                mapState.Buildings.Add(addedBuildingEntity.Origin);
            });
            
            Buildings.ObserveRemove().Subscribe(e =>
            {
                var removedBuildingEntityProxy = e.Value;
                var removedBuildingEntity = mapState.Buildings.FirstOrDefault(b => b.Id == removedBuildingEntityProxy.Id);
                mapState.Buildings.Remove(removedBuildingEntity);
            });
        }
    }
}