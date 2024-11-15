using System.Collections.Generic;
using mBuilding.Scripts.Game.Gameplay.View.Buildings;
using ObservableCollections;
using R3;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.Root.View
{
    public class WorldGameplayRootBinder : MonoBehaviour
    {
        private readonly Dictionary<int, BuildingBinder> _createBuildingsMap = new();
        private readonly CompositeDisposable _disposables = new();
        
        public void Bind(WorldGameplayRootViewModel viewModel)
        {
            foreach (var buildingViewModel in viewModel.AllBuildings)
            {
                CreateBuilding(buildingViewModel);
            }

            _disposables.Add(viewModel.AllBuildings.ObserveAdd()
                .Subscribe(e => CreateBuilding(e.Value)));
            
            _disposables.Add(viewModel.AllBuildings.ObserveRemove()
                .Subscribe(e => DestroyBuilding(e.Value)));
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }

        private void CreateBuilding(BuildingViewModel buildingViewModel)
        {
            var buildingLevel = buildingViewModel.Level.CurrentValue;
            var buildingType = buildingViewModel.TypeId;
            var prefabBuildingLevelPath = $"Prefabs/Gameplay/Buildings/Building_{buildingType}_{buildingLevel}";
            var buildingPrefab = Resources.Load<BuildingBinder>(prefabBuildingLevelPath);
            var createdBuilding = Instantiate(buildingPrefab);
            
            createdBuilding.Bind(buildingViewModel);

            _createBuildingsMap[buildingViewModel.BuildingEntityId] = createdBuilding;
        }

        private void DestroyBuilding(BuildingViewModel buildingViewModel)
        {
            if (_createBuildingsMap.TryGetValue(buildingViewModel.BuildingEntityId, out var buildingBinder))
            {
                Destroy(buildingBinder.gameObject);
                _createBuildingsMap.Remove(buildingViewModel.BuildingEntityId);
            }
        }
    }
}