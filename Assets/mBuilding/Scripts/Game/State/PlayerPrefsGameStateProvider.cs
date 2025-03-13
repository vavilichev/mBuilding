using System.Collections.Generic;
using mBuilding.Scripts.Game.State.GameResources;
using mBuilding.Scripts.Game.State.Maps;
using mBuilding.Scripts.Game.State.Root;
using Newtonsoft.Json;
using R3;
using Unity.VisualScripting;
using UnityEngine;

namespace mBuilding.Scripts.Game.State
{
    public class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);
        private const string GAME_SETTINGS_STATE_KEY = nameof(GAME_SETTINGS_STATE_KEY);
        
        public GameStateProxy GameState { get; private set; }
        public GameSettingsStateProxy SettingsState { get; private set; }
        
        private GameState _gameStateOrigin;
        private GameSettingsState _gameSettingsStateOrigin;
        
        public Observable<GameStateProxy> LoadGameState()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            };
            
            if (!PlayerPrefs.HasKey(GAME_STATE_KEY))
            {
                GameState = CreateGameStateFromSettings();
                Debug.Log("Game State created from settings: " + JsonConvert.SerializeObject(_gameStateOrigin, Formatting.Indented));

                SaveGameState();    // Сохраним дефолтное состояние
            }
            else
            {
                // Загружаем
                var json = PlayerPrefs.GetString(GAME_STATE_KEY);
                _gameStateOrigin = JsonConvert.DeserializeObject<GameState>(json);
                GameState = new GameStateProxy(_gameStateOrigin);
                
                Debug.Log("Game State loaded: " + json);
            }

            return Observable.Return(GameState);
        }
        
        public Observable<GameSettingsStateProxy> LoadSettingsState()
        {
            if (!PlayerPrefs.HasKey(GAME_SETTINGS_STATE_KEY))
            {
                SettingsState = CreateGameSettingsStateFromSettings();
                
                SaveSettingsState();    // Сохраним дефолтное состояние
            }
            else
            {
                // Загружаем
                var json = PlayerPrefs.GetString(GAME_SETTINGS_STATE_KEY);
                _gameSettingsStateOrigin = JsonConvert.DeserializeObject<GameSettingsState>(json);
                SettingsState = new GameSettingsStateProxy(_gameSettingsStateOrigin);
            }

            return Observable.Return(SettingsState);
        }

        public Observable<bool> SaveGameState()
        {
            var json = JsonConvert.SerializeObject(_gameStateOrigin, Formatting.Indented);
            PlayerPrefs.SetString(GAME_STATE_KEY, json);

            return Observable.Return(true);
        }
        
        public Observable<bool> SaveSettingsState()
        {
            var json = JsonConvert.SerializeObject(_gameSettingsStateOrigin, Formatting.Indented);
            PlayerPrefs.SetString(GAME_SETTINGS_STATE_KEY, json);

            return Observable.Return(true);
        }

        public Observable<bool> ResetGameState()
        {
            GameState = CreateGameStateFromSettings();
            SaveGameState();
            
            return Observable.Return(true);
        }
        
        public Observable<GameSettingsStateProxy> ResetSettingsState()
        {
            SettingsState = CreateGameSettingsStateFromSettings();
            SaveSettingsState();
            
            return Observable.Return(SettingsState);
        }
        
        private GameStateProxy CreateGameStateFromSettings()
        {
            // Состояние по умолчанию из настроек, мы делаем фейк
            _gameStateOrigin = new GameState
            {
                Maps = new List<MapData>(),
                Resources = new List<ResourceData>()
                {
                    new() { Amount = 0, ResourceType = ResourceType.SoftCurrency },
                    new() { Amount = 0, ResourceType = ResourceType.HardCurrency },
                    new() { Amount = 0, ResourceType = ResourceType.Wood }
                }
            };
                
            return new GameStateProxy(_gameStateOrigin);
        }
        
        private GameSettingsStateProxy CreateGameSettingsStateFromSettings()
        {
            // Состояние по умолчанию из настроек, мы делаем фейк
            _gameSettingsStateOrigin = new GameSettingsState()
            {
                MusicVolume = 8,
                SFXVolume = 8
            };
                
            return new GameSettingsStateProxy(_gameSettingsStateOrigin);
        }
    }
}