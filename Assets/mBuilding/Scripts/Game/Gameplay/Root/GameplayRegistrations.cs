﻿using BaCon;
using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Services;

namespace mBuilding.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            container.RegisterFactory(c => new SomeGameplayService(c.Resolve<SomeCommonService>())).AsSingle();
        }
    }
}