# BaCon
Basic DI Container for Unity engine. Supports registrations as single, as transient and registration instances. Tags are supported as well.

## Installation
Just download and import unitypackage file [from this page](https://github.com/vavilichev/BaCon/releases/tag/v.1.0)

# What it can

## Types of registrations

### As Single
Or singleton, only one instance can be created by resolving, if you are resolving many times, the same instance returns each time.

Registration:
```
container.RegisterFactory(_ => new MyService()).AsSingle();  // Without tags
container.RegisterFactory("my_awesome_tag_1", _ =>new MyService()).AsSingle();  // Using tags
container.RegisterFactory("my_awesome_tag_2", _ =>new MyService()).AsSingle();  // Using tags
container.RegisterFactory(c => new AnotherService(c.Resolve<MyService>())).AsSingle();   // Using resolved instance as a parameter
```

Resolving:
```
var serviceWithoutTag = container.Resolve<MyService>();   // Without tags
var serviceWithTag1 = container.Resolve<MyService>("my_awesome_tag_1");  // Using tags
var serviceWithTag2 = container.Resolve<MyService>("my_awesome_tag_2");  // Using tags
```

### As Transient
Each time creates a new instance of an object.

Registration:
```
container.RegisterFactory(_ => new ExampleProjectTransient());  // Without tags
```

Resolving:
```
var a = container.Resolve<ExampleProjectTransient>();
var b = container.Resolve<ExampleProjectTransient>();   // a != b
```

### Registration instances
You can register DI entry with already created instance. It registers as single.

Registration:
```
container.RegisterInstance(new MyInstance());
container.RegisterInstance("my_awesome_instance_tag", new MyInstance());   // Tags supports as well
```

Resolving:
```
var instance = container.Resolve<MyInstance>();
var instanceWithTag = container.Resolve<MyInstance>("my_awesome_instance_tag");
```

## Scoping
When you use scoping the only thing you should understand: child container can resolve instances from registered in the parent container AND parent container CAN'T resolve instances from registered in the child container.

```
// Game entry point
var projectContainer = new DIContainer();   // Can resolve only projectContainer instances
projectContainer.RegisterFactory(_ => new MyProjectService()).AsSingle();  // Without tags

...

// Scene 1 entry point
var sceneContainer1 = new DIContainer(projectContainer);   // Can resolve projectContainer instances but cannot resolve sceneContainer2 instances
sceneContainer1.RegisterFactory(_ => new MyFirstSceneService()).AsSingle();

...

// Scene 1 resolving
var projectService = sceneContainer1.Resolve<MyProjectService>();
var sceneService = sceneContainer1.Resolve<MyFirstSceneService>();
var sceneServiceFromProject = projectContainer.Resolve<MyFirstSceneService>();   // Error
...

// Scene 2 entry point
var sceneContainer2 = new DIContainer(projectContainer);   // Can resolve projectContainer instances but cannot resolve sceneContainer1 instances
sceneContainer2.RegisterFactory(_ => new MySecondSceneService()).AsSingle();

...

// Scene 2 resolving
var projectService = sceneContainer2.Resolve<MyProjectService>();
var sceneService = sceneContainer2.Resolve<MySecondSceneService>();
var sceneServiceFromProject = projectContainer.Resolve<MySecondSceneService>();   // Error
```
