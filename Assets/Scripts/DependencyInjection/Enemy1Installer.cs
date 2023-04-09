using FrogSurvive.Enemy1;
using FrogSurvive.Events;
using Zenject;

public class Enemy1Installer : Installer<Enemy1Settings, Enemy1BulletSettings, Enemy1Installer>
{
	public const string Enemy1GameObjectName = "Enemy1";
	public const string Enemy1BulletGameObjectName = "Enemy1Bullet";
	private readonly Enemy1Settings _enemy1Settings;
	private readonly Enemy1BulletSettings _enemy1BulletSettings;

	public Enemy1Installer(Enemy1Settings enemy1Settings, Enemy1BulletSettings enemy1BulletSettings)
	{
		_enemy1Settings = enemy1Settings;
		_enemy1BulletSettings = enemy1BulletSettings;
	}
	public override void InstallBindings()
	{
		Container.Bind<Enemy1Spawner>().AsSingle();
		Container.Bind<Enemy1BulletSpawner>().AsSingle();

		Container.BindFactoryCustomInterface<Enemy1Behaviour, Enemy1Behaviour.Factory, IFactory<Enemy1Behaviour>>()
				// This means that any time Xxx.Factory.Create is called, it will instantiate
				// this prefab and then search it for the Xxx component
				.FromComponentInNewPrefab(_enemy1Settings.Enemy1Prefab)
				// We can also tell Zenject what to name the new gameobject here
				.WithGameObjectName(Enemy1GameObjectName)
				// GameObjectGroup's are just game objects used for organization
				// This is nice so that it doesn't clutter up our scene hierarchy
				.UnderTransformGroup("Enemy1s");

		Container.BindFactoryCustomInterface<Enemy1BulletBehaviour, Enemy1BulletBehaviour.Factory, IFactory<Enemy1BulletBehaviour>>()
				.FromComponentInNewPrefab(_enemy1BulletSettings.Enemy1BulletPrefab)
				.WithGameObjectName(Enemy1BulletGameObjectName)
				.UnderTransformGroup("Enemy1s");
		
		//Container.DeclareSignal<Enemy1MovedSignal>();
		// Container.BindSignal<Enemy1MovedSignal>()
        //     .ToMethod<Enemy1BulletSpawner>(x => x.OnEnemy1Moved)
		// 	.FromResolve();

		//Container.DeclareSignal<Enemy1SpawnedSignal>();
		// Container.BindSignal<Enemy1SpawnedSignal>()
        //     .ToMethod<Enemy1BulletSpawner>(x => x.OnEnemy1Spawned)
		// 	.FromResolve();
		
	}
}
