using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingBinder : MonoBehaviour
    {
        public void Bind(BuildingViewModel viewModel)
        {
            transform.position = viewModel.Position.CurrentValue;
        }
    }
}