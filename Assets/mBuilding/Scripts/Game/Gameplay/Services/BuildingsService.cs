using System;
using System.Collections.Generic;
using mBuilding.Scripts.Game.Gameplay.Commands;
using mBuilding.Scripts.Game.Gameplay.View.Buildings;
using mBuilding.Scripts.Game.State.Buildings;
using mBuilding.Scripts.Game.State.cmd;
using ObservableCollections;
using R3;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.Services
{
    public class BuildingsService
    {
        private readonly ICommandProcessor _cmd;
        private readonly ObservableList<BuildingViewModel> _allBuildings = new();
        private readonly Dictionary<int, BuildingViewModel> _buildingsMap = new();

        public IObservableCollection<BuildingViewModel> AllBuildings => _allBuildings;

        public BuildingsService(IObservableCollection<BuildingEntityProxy> buildings, ICommandProcessor cmd)
        {
            _cmd = cmd;

            foreach (var buildingEntity in buildings)
            {
                CreateBuildingViewModel(buildingEntity);
            }

            buildings.ObserveAdd().Subscribe(e =>
            {
                CreateBuildingViewModel(e.Value);
            });

            buildings.ObserveRemove().Subscribe(e =>
            {
                RemoveBuildingViewModel(e.Value);
            });
        }

        public bool PlaceBuilding(string buildingTypeId, Vector3Int position)
        {
            var command = new CmdPlaceBuilding(buildingTypeId, position);
            var result = _cmd.Process(command);

            return result;
        }
        
        public bool MoveBuilding(int buildingEntityId, Vector3Int newPosition)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBuilding(int buildingEntityId)
        {
            throw new NotImplementedException();
        }

        private void CreateBuildingViewModel(BuildingEntityProxy buildingEntity)
        {
            var buildingViewModel = new BuildingViewModel(buildingEntity, this);
            
            _allBuildings.Add(buildingViewModel);
            _buildingsMap[buildingEntity.Id] = buildingViewModel;
        }

        private void RemoveBuildingViewModel(BuildingEntityProxy buildingEntity)
        {
            if (_buildingsMap.TryGetValue(buildingEntity.Id, out var buildingViewModel))
            {
                _allBuildings.Remove(buildingViewModel);
                _buildingsMap.Remove(buildingEntity.Id);
            }
        }
    }
}