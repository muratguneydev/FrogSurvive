using FrogSurvive.Enemy1;
using Zenject;

public class Enemy1Installer : Installer<Enemy1Settings, Enemy1Installer>
{
	public const string Enemy1GameObjectName = "Enemy1";
	private readonly Enemy1Settings _enemy1Settings;

	public Enemy1Installer(Enemy1Settings enemy1Settings)
	{
		_enemy1Settings = enemy1Settings;
	}
	public override void InstallBindings()
	{
		Container.Bind<Enemy1Spawner>().AsSingle();

		
		//Container.BindFactory<Enemy1Behaviour, Enemy1Behaviour.Factory>()
		Container.BindFactoryCustomInterface<Enemy1Behaviour, Enemy1Behaviour.Factory, IFactory<Enemy1Behaviour>>()
				// This means that any time Xxx.Factory.Create is called, it will instantiate
				// this prefab and then search it for the Xxx component
				.FromComponentInNewPrefab(_enemy1Settings.Enemy1Prefab)
				// We can also tell Zenject what to name the new gameobject here
				.WithGameObjectName(Enemy1GameObjectName)
				// GameObjectGroup's are just game objects used for organization
				// This is nice so that it doesn't clutter up our scene hierarchy
				.UnderTransformGroup("Enemy1s");
		//Container.Bind<IFactory<Enemy1Behaviour>>().To<Enemy1Behaviour.Factory>().AsSingle();

		// Container.BindInstance(_frogPlayerSettings.HorizontalVelocity).WhenInjectedInto<FrogPlayerMover>();

		// Container.DeclareSignal<FrogPlayerMovedSignal>();
		// Container.BindSignal<FrogPlayerMovedSignal>()
        //     .ToMethod<SpriteHorizontalDirectionManager>(x => x.OnFrogPlayerMoved)
		// 	.FromResolve();
		// Container.BindSignal<FrogPlayerMovedSignal>()
        //     .ToMethod<FrogPlayerAnimatorManager>(x => x.OnFrogPlayerMoved)
		// 	.FromResolve();

		// Container.Bind<SpriteHorizontalDirectionManager>().AsSingle();
		// Container.Bind<FrogPlayerAnimatorManager>().AsSingle();
		
	}
}
