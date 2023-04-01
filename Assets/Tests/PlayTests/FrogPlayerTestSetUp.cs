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
		_container.Rebind<KeyInput>().FromInstance(_keyInput);//For non-interface types, rebind cannot be AsSingle.
		_container.Bind<FrogPlayerBehaviour>().FromNewComponentOnNewGameObject()
			.AsSingle();
	}

	private void SetAnimatorControllerToBeAbleToGetAndSetAnimatorParameters()
	{
		//Note: This is to avoid the error: "Animator is not playing an AnimatorController"
		var animator = FrogPlayerBehaviour.gameObject.GetComponent<Animator>();
		var controller = UnityEditor.AssetDatabase.LoadAssetAtPath<AnimatorController>(AnimatorControllerAssetPath);
		animator.runtimeAnimatorController = controller;
	}
}
