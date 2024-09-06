using mBuilding.Scripts.Game.State.Buildings;
using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Root;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdPlaceBuildingHandler : ICommandHandler<CmdPlaceBuilding>
    {
        private readonly GameStateProxy _gameState;

        public CmdPlaceBuildingHandler(GameStateProxy gameState)
        {
            _gameState = gameState;
        }
        
        public bool Handle(CmdPlaceBuilding command)
        {
            var entityId = _gameState.GetEntityId();
            var newBuildingEntity = new BuildingEntity
            {
                Id = entityId,
                Position = command.Position,
                TypeId = command.BuildingTypeId
            };

            var newBuildingEntityProxy = new BuildingEntityProxy(newBuildingEntity);
            _gameState.Buildings.Add(newBuildingEntityProxy);

            return true;
        }
    }
}