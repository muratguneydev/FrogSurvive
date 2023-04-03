using FrogSurvive.Controllers;
using FrogSurvive.Enemy1;
using FrogSurvive.FrogPlayer;
using Scripts;
using UnityEditor.Animations;
using UnityEngine;
using Zenject;

public class FrogPlayerTestSetUp
{
	const int FrogHorizontalVelocityUnitsPerSecond = 10;
	private const string AnimatorControllerAssetPath = "Assets/Animations/PlayerHorizontalController.controller";
	private readonly DiContainer _container;
	private readonly KeyInput _keyInput;

	public FrogPlayerTestSetUp(DiContainer container, KeyInput keyInput)
	{
		_container = container;
		_keyInput = keyInput;
	}

	public void SetUp()
	{
		RegisterDependencies();
		SetAnimatorControllerToBeAbleToGetAndSetAnimatorParameters();
	}

	public FrogPlayerBehaviour FrogPlayerBehaviour => _container.Resolve<FrogPlayerBehaviour>();
	public GameObject GameObject => FrogPlayerBehaviour.gameObject;

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
		var enemy1Prefab = TestGameObject.GetNew();
		enemy1Prefab.AddComponent<Enemy1Behaviour>();
		var enemy1Settings = new Enemy1Settings(default, Vector3.zero, enemy1Prefab);
		_container.BindInstance(enemy1Settings);
		Enemy1Installer.Install(_container, enemy1Settings);

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

	private void SetAnimatorControllerToBeAbleToGetAndSetAnimatorParameters()
	{
		//Note: This is to avoid the error: "Animator is not playing an AnimatorController"
		var animator = FrogPlayerBehaviour.gameObject.GetComponent<Animator>();
		var controller = UnityEditor.AssetDatabase.LoadAssetAtPath<AnimatorController>(AnimatorControllerAssetPath);
		animator.runtimeAnimatorController = controller;
	}



}
