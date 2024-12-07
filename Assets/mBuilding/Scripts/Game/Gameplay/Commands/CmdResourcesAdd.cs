using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.GameResources;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdResourcesAdd : ICommand
    {
        public readonly ResourceType ResourceType;
        public readonly int Amount;
        
        public CmdResourcesAdd(ResourceType resourceType, int amount)
        {
            ResourceType = resourceType;
            Amount = amount;
        }
    }
}