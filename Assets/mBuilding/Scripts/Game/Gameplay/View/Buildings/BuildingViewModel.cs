using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Game.State.Buildings;

namespace mBuilding.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingsService _buildingsService;

        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingsService buildingsService)
        {
            _buildingEntity = buildingEntity;
            _buildingsService = buildingsService;
        }
    }
}