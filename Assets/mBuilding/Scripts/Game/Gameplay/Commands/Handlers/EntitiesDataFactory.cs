using System;
using mBuilding.Scripts.Game.Settings.Gameplay.Buildings;
using mBuilding.Scripts.Game.State.Entities;
using mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public static class EntitiesDataFactory
    {
        public static EntityData CreateEntity(EntityInitialStateSettings initialSettings)
        {
            switch (initialSettings.EntityType)
            {
                case EntityType.Building:
                    var buildingEntityData = CreateEntity<BuildingEntityData>(initialSettings);
                    UpdateBuildingEntity(buildingEntityData);
                    return buildingEntityData;
                
                default:
                    throw new Exception($"Not implemented entity creation: {initialSettings.EntityType}");
            }
        }
        
        private static T CreateEntity<T>(EntityInitialStateSettings initialSettings) where T : EntityData, new()
        {
            return CreateEntity<T>(
                initialSettings.EntityType,
                initialSettings.ConfigId,
                initialSettings.Level,
                initialSettings.InitialPosition);
        }

        private static T CreateEntity<T>(EntityType type, string configId, int level, Vector2Int position)
            where T : EntityData, new()
        {
            var entity = new T
            {
                Type = type,
                ConfigId = configId,
                Level = level,
                Position = position
            };

            return entity;
        }
        
        private static void UpdateBuildingEntity(BuildingEntityData buildingEntity)
        {
            buildingEntity.LastClickedTimeMS = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();      // Все рассчеты с момента построения здания, или можно прописать смещение в настройках
            buildingEntity.IsAutoCollectionEnabled = false;
        }
    }
}