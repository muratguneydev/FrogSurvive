using FrogSurvive.Enemy1;
using FrogSurvive.Events;
using FrogSurvive.FrogPlayer;
using Scripts;
using UnityEditor.Animations;
using UnityEngine;
using Zenject;
using FrogSurvive.Controllers;

public class TestDependencyInstaller
{
	const int FrogHorizontalVelocityUnitsPerSecond = 10;
	private const string AnimatorControllerAssetPath = "Assets/Animations/FrogPlayerController.controller";
	private readonly DiContainer _container;
	private readonly KeyInput _keyInput;
	private readonly Enemy1Settings _enemy1Settings;
	private readonly Enemy1BulletSettings _enemy1BulletSettings;

	public TestDependencyInstaller(DiContainer container, KeyInput keyInput, Enemy1Settings enemy1Settings, Enemy1BulletSettings enemy1BulletSettings)
		//GameSettings gameSettings)
	{
		_container = container;
		_keyInput = keyInput;
		_enemy1Settings = enemy1Settings;
		_enemy1BulletSettings = enemy1BulletSettings;
		//GameSettings = gameSettings;
	}

	public TestDependencyInstaller(DiContainer container, KeyInput keyInput)
		: this(container, keyInput,
				new Enemy1Settings(new Velocity(10, Vector2.down), Vector3.zero, PrefabFactory.Enemy1),
				new Enemy1BulletSettings(10f, PrefabFactory.Enemy1Bullet, 2f))
				//new GameSettingsStub(TestGameObject.GetNew()))
	{
		
	}

	public TestDependencyInstaller(DiContainer container)
		: this(container, KeyInputStub.None)
	{

	}

	// public TestDependencyInstaller(DiContainer container, GameSettings gameSettings)
	// 	: this(container, KeyInputStub.None,
	// 			new Enemy1Settings(new Velocity(10, Vector2.down), Vector3.zero, PrefabFactory.Enemy1),
	// 			new Enemy1BulletSettings(10f, PrefabFactory.Enemy1Bullet),
	// 			gameSettings)
	// {
		
	// }

	public void Install()
	{
		RegisterDependencies();
		SetAnimatorControllerToBeAbleToGetAndSetAnimatorParameters();
	}

	public FrogPlayerBehaviour FrogPlayerBehaviour => _container.Resolve<FrogPlayerBehaviour>();
	public GameObject FrogPlayerGameObject => FrogPlayerBehaviour.gameObject;
	public IEventBus EventBus => _container.Resolve<IEventBus>();
	public GameController GameController => _container.Resolve<GameController>();

	public GameOverBehaviour GameOverBehaviour => _container.Resolve<GameOverBehaviour>();
	public GameObject GameOverGameObject => GameOverBehaviour.gameObject;

	public Enemy1Behaviour Enemy1Behaviour => _container.Resolve<Enemy1Behaviour>();


	private void RegisterDependencies()
	{
		_container.Install<CoreInstaller>();
		FrogPlayerInstaller.Install(_container, new FrogPlayerSettings(FrogHorizontalVelocityUnitsPerSecond));
		InstallEnemy1Dependencies();

		_container.Rebind<KeyInput>().FromInstance(_keyInput);//For non-interface types, rebind cannot be AsSingle.
		_container.Bind<FrogPlayerBehaviour>().FromNewComponentOnNewGameObject()
			.AsSingle();
		_container.Bind<GameOverBehaviour>().FromNewComponentOnNewGameObject()
			.AsSingle();
	}

	private void InstallEnemy1Dependencies()
	{
		//TODO: For some reason we can't reference IInitializable here as commented out below, and use a dummy for GameController
		//to avoid dependency to objects which are not really needed here.
		
		_container.BindInstance(_enemy1Settings);
		_container.BindInstance(_enemy1BulletSettings);
		Enemy1Installer.Install(_container, _enemy1Settings, _enemy1BulletSettings);
		_container.Bind<Enemy1Behaviour>().FromNewComponentOnNewGameObject().AsSingle();
		_container.Bind<Enemy1BulletBehaviour>().AsSingle();

		//REbind interfaces???
		//_container.Rebind<IInitializable>().FromInstance(new GameControllerDummy());
	}

	private void SetAnimatorControllerToBeAbleToGetAndSetAnimatorParameters()
	{
		//Note: This is to avoid the error: "Animator is not playing an AnimatorController"
		var animator = FrogPlayerBehaviour.gameObject.GetComponent<Animator>();
		var controller = UnityEditor.AssetDatabase.LoadAssetAtPath<AnimatorController>(AnimatorControllerAssetPath);
		animator.runtimeAnimatorController = controller;
	}



}
