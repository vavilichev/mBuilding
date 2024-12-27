namespace mBuilding.Scripts.MVVM.UI
{
    public interface IWindowBinder
    {
        void Bind(WindowViewModel viewModel);
        void Close();
    }
}