using FrogSurvive.Controllers;
using NUnit.Framework;

public class GameControllerTests
{
	[Test]
	public void ShouldSpawnEnemy1()
	{
		//Arrange
		var enemy1Spawner = new Enemy1SpawnerSpy();
		var gameController = new GameController(enemy1Spawner);
		//Act
		gameController.Initialize();
		//Assert
		Assert.IsTrue(enemy1Spawner.IsSpawned);

	}
}