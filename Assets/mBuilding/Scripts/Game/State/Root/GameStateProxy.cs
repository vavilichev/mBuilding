using System.Linq;
using mBuilding.Scripts.Game.State.Maps;
using ObservableCollections;
using R3;

namespace mBuilding.Scripts.Game.State.Root
{
    public class GameStateProxy
    {
        private readonly GameState _gameState;
        public readonly ReactiveProperty<int> CurrentMapId = new();
        public ObservableList<Map> Maps { get; } = new();

        public GameStateProxy(GameState gameState)
        {
            _gameState = gameState;
            gameState.Maps.ForEach(mapOrigin => Maps.Add(new Map(mapOrigin)));
            
            Maps.ObserveAdd().Subscribe(e =>
            {
                var addedMap = e.Value;
                gameState.Maps.Add(addedMap.Origin);
            });
            
            Maps.ObserveRemove().Subscribe(e =>
            {
                var removedMap = e.Value;
                var removedMapState = gameState.Maps.FirstOrDefault(b => b.Id == removedMap.Id);
                gameState.Maps.Remove(removedMapState);
            });
            
            CurrentMapId.Subscribe(newValue => { gameState.CurrentMapId = newValue; });
        }

        public int CreateEntityId()
        {
            return _gameState.CreateEntityId();
        }
    }
}