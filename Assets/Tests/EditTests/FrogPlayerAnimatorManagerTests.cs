using FrogSurvive.Events;
using NUnit.Framework;
using UnityEditor.Animations;
using UnityEngine;

public class FrogPlayerAnimatorManagerTests
{
	private const string VerticalMoveParameter = "isPlayerMovingVertically";
	private const string HorizontalMoveParameter = "isPlayerMovingHorizontally";
	private const string AnimatorControllerAssetPath = "Assets/Animations/PlayerHorizontalController.controller";

	[Test]
	public void Should_ActivateVerticalMoveAnimation_WhenMovingUp()
	{
		//Arrange
		var sut = new FrogPlayerAnimatorManager();
		var gameObject = PopulateGameObject();
		//Act
		sut.OnFrogPlayerMoved(new FrogPlayerMovedSignal(gameObject, Vector2.up));
		//Assert
		Assert.IsTrue(gameObject.GetComponent<Animator>().GetBool(VerticalMoveParameter));
	}

	[Test]
	public void Should_ActivateVerticalMoveAnimation_WhenMovingDown()
	{
		//Arrange
		var sut = new FrogPlayerAnimatorManager();
		var gameObject = PopulateGameObject();
		//Act
		sut.OnFrogPlayerMoved(new FrogPlayerMovedSignal(gameObject, Vector2.down));
		//Assert
		Assert.IsTrue(gameObject.GetComponent<Animator>().GetBool(VerticalMoveParameter));
	}

	[Test]
	public void Should_ActivateHorizontalMoveAnimation_WhenMovingRight()
	{
		//Arrange
		var sut = new FrogPlayerAnimatorManager();
		var gameObject = PopulateGameObject();
		//Act
		sut.OnFrogPlayerMoved(new FrogPlayerMovedSignal(gameObject, Vector2.right));
		//Assert
		Assert.IsTrue(gameObject.GetComponent<Animator>().GetBool(HorizontalMoveParameter));
	}

	[Test]
	public void Should_ActivateHorizontalMoveAnimation_WhenMovingLeft()
	{
		//Arrange
		var sut = new FrogPlayerAnimatorManager();
		var gameObject = PopulateGameObject();
		//Act
		sut.OnFrogPlayerMoved(new FrogPlayerMovedSignal(gameObject, Vector2.left));
		//Assert
		Assert.IsTrue(gameObject.GetComponent<Animator>().GetBool(HorizontalMoveParameter));
	}

	private static GameObject PopulateGameObject()
	{
		var gameObject = TestGameObject.GetNew();
		var animator = gameObject.AddComponent<Animator>();
		var controller = UnityEditor.AssetDatabase.LoadAssetAtPath<AnimatorController>(AnimatorControllerAssetPath);
		animator.runtimeAnimatorController = controller;
		return gameObject;
	}
}