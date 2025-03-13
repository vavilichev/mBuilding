using System.Collections.Generic;
using mBuilding.Scripts.Game.Settings.Gameplay.Buildings;
using R3;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        // private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingSettings _buildingSettings;
        // private readonly BuildingsService _buildingsService;
        private readonly Dictionary<int, BuildingLevelSettings> _levelSettingsMap = new();
        
        public readonly int BuildingEntityId;
        public ReadOnlyReactiveProperty<Vector3Int> Position { get; }
        public ReadOnlyReactiveProperty<int> Level { get; }
        public readonly string TypeId;
        
        // public BuildingViewModel(
        //     BuildingEntityProxy buildingEntity, 
        //     BuildingSettings buildingSettings,
        //     BuildingsService buildingsService)
        // {
        //     TypeId = buildingEntity.TypeId;
        //     BuildingEntityId = buildingEntity.Id;
        //     Level = buildingEntity.Level;
        //
        //     _buildingEntity = buildingEntity;
        //     _buildingSettings = buildingSettings;
        //     _buildingsService = buildingsService;
        //     
        //     foreach (var buildingLevelSettings in buildingSettings.LevelsSettings)
        //     {
        //         _levelSettingsMap[buildingLevelSettings.Level] = buildingLevelSettings;
        //     }
        //
        //     Position = buildingEntity.Position;
        // }

        public BuildingLevelSettings GetLevelSettings(int level)
        {
            return _levelSettingsMap[level];
        }
    }
}