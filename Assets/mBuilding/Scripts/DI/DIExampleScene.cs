using UnityEngine;

namespace DI
{
    public class DIExampleScene : MonoBehaviour
    {
        public void Init(DIContainer projectContainer)
        {
            // Используем уровень проекта, чтобы вытащить то, что нам надо
            // var serviceWithoutTag = projectContainer.Resolve<MyAwesomeProjectService>();
            // var service1 = projectContainer.Resolve<MyAwesomeProjectService>("option 1");
            // var service2 = projectContainer.Resolve<MyAwesomeProjectService>("option 2");

            var sceneContainer = new DIContainer(projectContainer);
            sceneContainer.RegisterSingleton(c => new MySceneService(c.Resolve<MyAwesomeProjectService>()));
            sceneContainer.RegisterSingleton(_ => new MyAwesomeFactory());
            sceneContainer.RegisterInstance(new MyAwesomeObject("instance", 10));

            var objectsFactory = sceneContainer.Resolve<MyAwesomeFactory>();
            
            for (var i = 0; i < 3; i++)
            {
                var id = $"o{i}";
                var o = objectsFactory.CreateInstance(id, i);
                Debug.Log($"Object created with factory.\n{o}");
            }
            
            var instance = sceneContainer.Resolve<MyAwesomeObject>();
            Debug.Log($"Object instance.\n{instance}");
        }
    }
}