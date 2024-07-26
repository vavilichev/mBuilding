using R3;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.Root.View
{
    public class UIGameplayRootBinder : MonoBehaviour
    {
        private Subject<Unit> _exitSceneSignalSubj;

        public void HandleGoToMainMenuButtonClick()
        {
            _exitSceneSignalSubj?.OnNext(Unit.Default);
        }

        public void Bind(Subject<Unit> exitSceneSignalSubj)
        {
            _exitSceneSignalSubj = exitSceneSignalSubj;
        }
    }
}
