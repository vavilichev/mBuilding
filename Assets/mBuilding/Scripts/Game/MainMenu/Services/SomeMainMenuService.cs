using mBuilding.Scripts.Services;
using UnityEngine;

namespace mBuilding.Scripts.Game.MainMenu.Services
{
    public class SomeMainMenuService
    {
        private readonly SomeCommonService _someCommonService;

        public SomeMainMenuService(SomeCommonService someCommonService)
        {
            _someCommonService = someCommonService;
            Debug.Log(GetType().Name + " has been created");
        }
    }
}