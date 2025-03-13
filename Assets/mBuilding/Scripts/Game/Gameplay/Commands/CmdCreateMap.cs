using mBuilding.Scripts.Game.State.cmd;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdCreateMap: ICommand
    {
        public readonly int MapId;
        
        public CmdCreateMap(int mapId)
        {
            MapId = mapId;
        }
    }
}