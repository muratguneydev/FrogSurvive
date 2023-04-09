using FrogSurvive.Controllers;
using NUnit.Framework;

public class GameControllerTests
{
	[Test]
	public void ShouldSpawnEnemy1()
	{
		//Arrange
		var enemy1SpawnerSpy = new Enemy1SpawnerSpy();
		//var enemy1BulletSpawnerSpy = new Enemy1BulletSpawnerSpy();
		var gameController = new GameController(enemy1SpawnerSpy);
		//Act
		gameController.Initialize();
		//Assert
		Assert.IsTrue(enemy1SpawnerSpy.IsSpawned);
		//Assert.IsTrue(enemy1BulletSpawnerSpy.IsSpawned);
	}
}