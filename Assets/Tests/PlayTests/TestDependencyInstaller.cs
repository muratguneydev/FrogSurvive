using FrogSurvive.Enemy1;
using FrogSurvive.FrogPlayer;
using Scripts;
using UnityEditor.Animations;
using UnityEngine;
using Zenject;

public class TestDependencyInstaller
{
	const int FrogHorizontalVelocityUnitsPerSecond = 10;
	private const string AnimatorControllerAssetPath = "Assets/Animations/PlayerHorizontalController.controller";
	private readonly DiContainer _container;
	private readonly KeyInput _keyInput;
	private readonly Enemy1Settings _enemy1Settings;

	public TestDependencyInstaller(DiContainer container, KeyInput keyInput, Enemy1Settings enemy1Settings)
	{
		_container = container;
		_keyInput = keyInput;
		_enemy1Settings = enemy1Settings;
	}

	public TestDependencyInstaller(DiContainer container, KeyInput keyInput)
		: this(container, keyInput, new Enemy1Settings(new Velocity(10, Vector2.down), Vector3.zero, PrefabFactory.Enemy1))
	{
		
	}

	public void Install()
	{
		RegisterDependencies();
		SetAnimatorControllerToBeAbleToGetAndSetAnimatorParameters();
	}

	public FrogPlayerBehaviour FrogPlayerBehaviour => _container.Resolve<FrogPlayerBehaviour>();
	public GameObject FrogPlayerGameObject => FrogPlayerBehaviour.gameObject;

	// public GameObject GetEnemy1()
	// 	=> _container.Resolve<Enemy1Spawner>().Spawn();
	// public Enemy1Behaviour Enemy1Behaviour => _container.Resolve<Enemy1Behaviour>();
	// public GameObject Enemy1GameObject => Enemy1Behaviour.gameObject;


	private void RegisterDependencies()
	{
		_container.Install<CoreInstaller>();
		FrogPlayerInstaller.Install(_container, new FrogPlayerSettings(FrogHorizontalVelocityUnitsPerSecond));
		InstallEnemy1Dependencies();

		_container.Rebind<KeyInput>().FromInstance(_keyInput);//For non-interface types, rebind cannot be AsSingle.
		_container.Bind<FrogPlayerBehaviour>().FromNewComponentOnNewGameObject()
			.AsSingle();
	}

	private void InstallEnemy1Dependencies()
	{
		//TODO: For some reason we can't reference IInitializable here as commented out below, and use a dummy for GameController
		//to avoid dependency to objects which are not really needed here.
		
		_container.BindInstance(_enemy1Settings);
		//Debug.Log($"Registering:{_enemy1Settings}");
		Enemy1Installer.Install(_container, _enemy1Settings);
		_container.Bind<Enemy1Behaviour>()//..FromNewComponentOnNewGameObject()
		 	.AsSingle();

		//REbind interfaces???
		//_container.Rebind<GameController>().FromInstance(new GameControllerDummy());//For non-interface types, rebind cannot be AsSingle.
		//_container.Rebind<IInitializable>().FromInstance(new GameControllerDummy());

		// 	private class GameControllerDummy : GameController
		// {
		// 	public GameControllerDummy() : base(null)
		// 	{
		// 	}

		// 	public override void Initialize()
		// 	{

		// 	}
		// }
	}

	// private static Enemy1Settings GetDefaultEnemy1Settings()
	// {
	// 	var enemy1Prefab = TestGameObject.GetNew();
	// 	enemy1Prefab.AddComponent<Enemy1Behaviour>();
	// 	var enemy1Settings = new Enemy1Settings(default, Vector3.zero, enemy1Prefab);
	// 	return enemy1Settings;
	// }

	private void SetAnimatorControllerToBeAbleToGetAndSetAnimatorParameters()
	{
		//Note: This is to avoid the error: "Animator is not playing an AnimatorController"
		var animator = FrogPlayerBehaviour.gameObject.GetComponent<Animator>();
		var controller = UnityEditor.AssetDatabase.LoadAssetAtPath<AnimatorController>(AnimatorControllerAssetPath);
		animator.runtimeAnimatorController = controller;
	}



}
