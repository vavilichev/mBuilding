using System;
using System.Linq;
using mBuilding.Scripts.Game.State.Buildings;
using mBuilding.Scripts.Game.State.Root;
using mBuilding.Scripts.Services;
using ObservableCollections;
using R3;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.Services
{
    public class SomeGameplayService : IDisposable
    {
        private readonly GameStateProxy _gameState;
        private readonly SomeCommonService _someCommonService;

        public SomeGameplayService(GameStateProxy gameState, SomeCommonService someCommonService)
        {
            _gameState = gameState;
            _someCommonService = someCommonService;
            Debug.Log(GetType().Name + " has been created");
            
            gameState.Buildings.ForEach(b => Debug.Log($"Building: {b.TypeId}"));
            gameState.Buildings.ObserveAdd().Subscribe(e => Debug.Log($"Building added: {e.Value.TypeId}"));
            gameState.Buildings.ObserveRemove().Subscribe(e => Debug.Log($"Building removed: {e.Value.TypeId}"));
            
            AddBuilding("Васян");
            AddBuilding("Стасян");
            AddBuilding("Реклама");
            
            RemoveBuilding("Реклама");
        }

        public void Dispose()
        {
            Debug.Log("Подчистить все подписьки");
        }
        
        private void AddBuilding(string buildingTypeId)
        {
            var building = new BuildingEntity
            {
                TypeId = buildingTypeId
            };
            var buildingProxy = new BuildingEntityProxy(building);
            _gameState.Buildings.Add(buildingProxy);
        }

        private void RemoveBuilding(string buildingTypeId)
        {
            var buildingEntity = _gameState.Buildings.FirstOrDefault(b => b.TypeId == buildingTypeId);
            
            if (buildingEntity != null)
            {
                _gameState.Buildings.Remove(buildingEntity);
            }
        }
    }
}