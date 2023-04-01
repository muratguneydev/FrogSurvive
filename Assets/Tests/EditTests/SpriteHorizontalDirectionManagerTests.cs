using FrogSurvive.Events;
using FrogSurvive.FrogPlayer;
using NUnit.Framework;
using UnityEngine;

public class SpriteHorizontalDirectionManagerTests
{
	private static readonly SpriteHorizontalDirectionManager Sut = new();

	[Test]
    public void Should_KeepFacingRight_WhenDirectionIsRight()
	{
		//Arrange
		var gameObject = TestGameObject.GetNew();
		gameObject.transform.localScale = new Vector3(2, 2, 2);
		var signal = new FrogPlayerMovedSignal(gameObject, Vector2.right);
		//Act
		Sut.FrogPlayerMoved(signal);
		//Assert
		Assert.AreEqual(gameObject.transform.localScale, new Vector3(2, 2, 2));
	}

	[Test]
    public void Should_KeepFacingLeft_WhenDirectionIsLeft()
	{
		//Arrange
		var gameObject = TestGameObject.GetNew();
		gameObject.transform.localScale = new Vector3(-2, 2, 2);
		var signal = new FrogPlayerMovedSignal(gameObject, Vector2.left);
		//Act
		Sut.FrogPlayerMoved(signal);
		//Assert
		Assert.AreEqual(gameObject.transform.localScale, new Vector3(-2, 2, 2));
	}
	
	[Test]
    public void Should_StartFacingLeft_WhenDirectionChangedFromRightToLeft()
	{
		//Arrange
		var gameObject = TestGameObject.GetNew();
		gameObject.transform.localScale = new Vector3(2, 2, 2);
		var signal = new FrogPlayerMovedSignal(gameObject, Vector2.left);
		//Act
		Sut.FrogPlayerMoved(signal);
		//Assert
		Assert.AreEqual(gameObject.transform.localScale, new Vector3(-2, 2, 2));
	}

	[Test]
    public void Should_StartFacingRight_WhenDirectionChangedFromLeftToRight()
	{
		//Arrange
		var gameObject = TestGameObject.GetNew();
		gameObject.transform.localScale = new Vector3(-2, 2, 2);
		var signal = new FrogPlayerMovedSignal(gameObject, Vector2.right);
		//Act
		Sut.FrogPlayerMoved(signal);
		//Assert
		Assert.AreEqual(gameObject.transform.localScale, new Vector3(2, 2, 2));
	}
}