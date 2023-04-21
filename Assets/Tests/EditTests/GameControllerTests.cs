using FrogSurvive.Controllers;
using FrogSurvive.Events;
using NUnit.Framework;
using Scripts;
using UnityEngine;

public class GameControllerTests
{
	private static readonly Enemy1SpawnerSpy Enemy1SpawnerSpy = new Enemy1SpawnerSpy();
	private static readonly GameObjectDestroyerSpy GameObjectDestroyerSpy = new GameObjectDestroyerSpy();
	
	private static readonly GameController GameController = new GameController(Enemy1SpawnerSpy, GameObjectDestroyerSpy);

	[Test]
	public void ShouldSpawnEnemy1_WhenInitialized()
	{
		//Act
		GameController.Initialize();
		//Assert
		Assert.IsTrue(Enemy1SpawnerSpy.IsSpawned);
	}

	[TestCase(true, true)]
	[TestCase(false, false)]
	public void ShouldDestroyObject_WhenHitTheWallEventReceived(bool isDestroyable, bool expectedDestroyedResult)
	{
		//Arrange
		var gameObjectHit = TestGameObject.GetNew();
		//Act
		GameController.OnHitTheWall(new HitTheWallUISignal(gameObjectHit, isDestroyable));
		//Assert
		Assert.AreEqual(expectedDestroyedResult, GameObjectDestroyerSpy.IsDestroyed(gameObjectHit));
	}

	// [Test]
	// public void ShouldShowGameOverScreen_WhenFrogPlayerDiedEventReceived()
	// {
	// 	//Arrange
	// 	GameSettings.GameOverScreen.SetActive(false);
	// 	//Act
	// 	GameController.OnFrogPlayerDied(new FrogPlayerDiedSignal(frogPlayer: TestGameObject.GetNew()));
	// 	//Assert
	// 	Assert.IsTrue(GameSettings.GameOverScreen.activeSelf);
	// }
}
