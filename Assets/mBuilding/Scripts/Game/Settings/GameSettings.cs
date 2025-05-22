using mBuilding.Scripts.Game.Settings.Gameplay.Buildings;
using mBuilding.Scripts.Game.Settings.Gameplay.Maps;
using UnityEngine;
using UnityEngine.Serialization;

namespace mBuilding.Scripts.Game.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings/New Game Settings")]
    public class GameSettings : ScriptableObject
    {
        [FormerlySerializedAs("BuildingsSettings")] public EntitiesSettings entitiesSettings;
        public MapsSettings MapsSettings;
    }
}