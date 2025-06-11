using System;
using System.Collections.Generic;
using mBuilding.Scripts.Game.Gameplay.Commands;
using mBuilding.Scripts.Game.Gameplay.View.Buildings;
using mBuilding.Scripts.Game.Settings.Gameplay.Buildings;
using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Entities;
using mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings;
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
        private readonly Dictionary<string, BuildingSettings> _buildingSettingsMap = new();

        public IObservableCollection<BuildingViewModel> AllBuildings => _allBuildings;

        public BuildingsService(
            IObservableCollection<Entity> entities, 
            EntitiesSettings entitiesSettings, 
            ICommandProcessor cmd)
        {
            _cmd = cmd;
            
            foreach (var buildingSettings in entitiesSettings.Buildings)
            {
                _buildingSettingsMap[buildingSettings.ConfigId] = buildingSettings;
            }

            foreach (var entity in entities)
            {
                if (entity is BuildingEntity buildingEntity)
                {
                    CreateBuildingViewModel(buildingEntity);
                }
            }

            entities.ObserveAdd().Subscribe(e =>
            {
                var entity = e.Value;
                if (entity is BuildingEntity buildingEntity)
                {
                    CreateBuildingViewModel(buildingEntity);
                }
            });

            entities.ObserveRemove().Subscribe(e =>
            {
                var entity = e.Value;

                if (entity is BuildingEntity buildingEntity)
                {
                    RemoveBuildingViewModel(buildingEntity);
                }
            });
        }

        public bool PlaceBuilding(string buildingConfigId, int level, Vector2Int position)
        {
            var command = new CmdPlaceEntity(EntityType.Building, buildingConfigId, level, position);
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

        private void CreateBuildingViewModel(BuildingEntity buildingEntity)
        {
            var buildingSettings = _buildingSettingsMap[buildingEntity.ConfigId];
            var buildingViewModel = new BuildingViewModel(buildingEntity, buildingSettings, this);
            
            _allBuildings.Add(buildingViewModel);
            _buildingsMap[buildingEntity.UniqueId] = buildingViewModel;
        }

        private void RemoveBuildingViewModel(BuildingEntity buildingEntity)
        {
            if (_buildingsMap.TryGetValue(buildingEntity.UniqueId, out var buildingViewModel))
            {
                _allBuildings.Remove(buildingViewModel);
                _buildingsMap.Remove(buildingEntity.UniqueId);
            }
        }
    }
}