
using mBuilding.Scripts.Game.Gameplay.Services;
using UnityEngine;

namespace mBuilding.Game
{
    public class CheatsService
    {
        private readonly BuildingsService _buildingsService;

        public CheatsService(BuildingsService buildingsService)
        {
            _buildingsService = buildingsService;
        }
        
        public void TryApplyCheat(string cheatText)
        {
            Debug.Log($"Try to apply cheat: {cheatText}");
            
            var words = cheatText.Split(' ');
            
            if (words[0].ToUpper() == "CREATE")
            {
                HandleCheatEntityCreation(words);
                return;
            }
        }

        private void HandleCheatEntityCreation(string[] words)
        {
            if (words[1].ToUpper() == "BUILDING")
            {
                HandleCheatBuildingCreation(words);
                return;
            }
        }

        private void HandleCheatBuildingCreation(string[] words)
        {
            var buildingConfigId = words[2];
            var level = int.Parse(words[3]);
            var posX = int.Parse(words[4]);
            var posY = int.Parse(words[5]);
            var position = new Vector2Int(posX, posY);

            _buildingsService.PlaceBuilding(buildingConfigId, level, position);
        }
    }
}