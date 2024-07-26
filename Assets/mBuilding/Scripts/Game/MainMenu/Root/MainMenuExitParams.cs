namespace mBuilding.Scripts.Game.MainMenu.Root
{
    public class MainMenuExitParams
    {
        public SceneEnterParams TargetSceneEnterParams { get; }
        
        public MainMenuExitParams(SceneEnterParams targetSceneEnterParams)
        {
            TargetSceneEnterParams = targetSceneEnterParams;
        }
    }
}