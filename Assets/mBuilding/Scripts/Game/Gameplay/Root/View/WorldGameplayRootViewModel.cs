using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Game.Gameplay.View.Buildings;
using ObservableCollections;

namespace mBuilding.Scripts.Game.Gameplay.Root.View
{
    public class WorldGameplayRootViewModel
    {
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;

        public WorldGameplayRootViewModel(BuildingsService buildingsService)
        {
            AllBuildings = buildingsService.AllBuildings;
        }
    }
}