using mBuilding.Scripts.Game.State.cmd;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdCreateMapState: ICommand
    {
        public readonly int MapId;
        
        public CmdCreateMapState(int mapId)
        {
            MapId = mapId;
        }
    }
}