using System.Collections.Generic;
using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Game.Settings.Gameplay.Buildings;
using mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings;
using R3;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private readonly BuildingEntity _buildingEntity;
        private readonly BuildingSettings _buildingSettings;
        private readonly BuildingsService _buildingsService;
        private readonly Dictionary<int, BuildingLevelSettings> _levelSettingsMap = new();
        
        public readonly int BuildingEntityId;
        public ReadOnlyReactiveProperty<Vector2Int> Position { get; }
        public ReadOnlyReactiveProperty<int> Level { get; }
        public readonly string ConfigId;
        
        public BuildingViewModel(
            BuildingEntity buildingEntity, 
            BuildingSettings buildingSettings,
            BuildingsService buildingsService)
        {
            ConfigId = buildingEntity.ConfigId;
            BuildingEntityId = buildingEntity.UniqueId;
            Level = buildingEntity.Level;
        
            _buildingEntity = buildingEntity;
            _buildingSettings = buildingSettings;
            _buildingsService = buildingsService;
            
            foreach (var buildingLevelSettings in buildingSettings.Levels)
            {
                _levelSettingsMap[buildingLevelSettings.Level] = buildingLevelSettings;
            }
        
            Position = buildingEntity.Position;
        }

        public BuildingLevelSettings GetLevelSettings(int level)
        {
            return _levelSettingsMap[level];
        }
    }
}