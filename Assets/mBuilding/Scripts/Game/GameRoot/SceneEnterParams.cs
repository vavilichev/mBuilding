namespace mBuilding.Scripts
{
    public abstract class SceneEnterParams
    {
        public string SceneName { get; }

        public SceneEnterParams(string sceneName)
        {
            SceneName = sceneName;
        }

        public T As<T>() where T : SceneEnterParams
        {
            return (T)this;
        }
    }
}