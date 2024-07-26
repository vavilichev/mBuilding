using System;
using mBuilding.Scripts.Game.Gameplay.Root;
using mBuilding.Scripts.Game.MainMenu.Root.View;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

namespace mBuilding.Scripts.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;

        public Observable<MainMenuExitParams> Run(UIRootView uiRoot, MainMenuEnterParams enterParams)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);
            
            var exitSignalSubj = new Subject<Unit>();
            uiScene.Bind(exitSignalSubj);

            Debug.Log($"MAIN MENU ENTRY POINT: Run main menu scene. Results: {enterParams?.Result}");

            var saveFileName = "ololo.save";
            var levelNumber = Random.Range(0, 300);
            var gameplayEnterParams = new GameplayEnterParams(saveFileName, levelNumber);
            var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);
            var exitToGameplaySceneSignal = exitSignalSubj.Select(_ => mainMenuExitParams);
            
            return exitToGameplaySceneSignal;
        }   
    }
}