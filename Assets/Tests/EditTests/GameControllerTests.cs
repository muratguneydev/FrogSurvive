using FrogSurvive.Controllers;
using FrogSurvive.Events;
using NUnit.Framework;

public class GameControllerTests
{
	private static readonly Enemy1SpawnerSpy Enemy1SpawnerSpy = new();
	private static readonly GameObjectDestroyerSpy GameObjectDestroyerSpy = new();
	private static readonly SceneManagerWrapperSpy SceneManagerWrapperSpy = new();
	private static EventBusSpy<GameResetSignal> EventBusSpy = new();
	private static readonly GameController GameController = new GameController(Enemy1SpawnerSpy, GameObjectDestroyerSpy, SceneManagerWrapperSpy,
		EventBusSpy);

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

	[Test]
	public void ShouldResetGame_WhenGameResetEventReceived()
	{
		//Arrange
		var gameOverScreen = TestGameObject.GetNew();
		gameOverScreen.SetActive(true);
		//Act
		GameController.OnGameReset(new ResetButtonClickedUISignal(gameOverScreen));
		//Assert
		Assert.IsFalse(gameOverScreen.activeSelf, "Game over screen is not disabled after reset.");
		Assert.IsTrue(SceneManagerWrapperSpy.IsSceneLoaded("MainScene"), "MainScene is not loaded after reset.");
		var (isExpectedEventFired, _) = EventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isExpectedEventFired, "GameResetEvent is not fired.");
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
