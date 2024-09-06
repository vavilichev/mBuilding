namespace mBuilding.Scripts.Game.State.cmd
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        bool Handle(TCommand command);
    }
}