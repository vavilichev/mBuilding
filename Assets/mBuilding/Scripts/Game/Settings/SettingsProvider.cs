using System.Threading.Tasks;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings
{
    public class SettingsProvider : ISettingsProvider
    {
        public GameSettings GameSettings => _gameSettings;
        public ApplicationSettings ApplicationSettings { get; }

        private GameSettings _gameSettings;
        
        public SettingsProvider()
        {
            ApplicationSettings = Resources.Load<ApplicationSettings>("ApplicationSettings");
        }
        
        public Task<GameSettings> LoadGameSettings()
        {
            _gameSettings = Resources.Load<GameSettings>("GameSettings");
            
            return Task.FromResult(_gameSettings);
        }
    }
}