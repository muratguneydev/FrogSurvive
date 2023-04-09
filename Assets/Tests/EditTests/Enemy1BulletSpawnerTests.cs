using FrogSurvive.Enemy1;
using FrogSurvive.Events;
using NUnit.Framework;
using UnityEngine;

public class Enemy1BulletSpawnerTests
{
	private const float SpeedInUnitsPerSecond = 10f;
	private static Vector3 FrogPlayerPosition = new Vector3(25, 3, 0);
	private static Enemy1BulletSettings Enemy1BulletSettings = new Enemy1BulletSettings(SpeedInUnitsPerSecond, TestGameObject.GetNew());
	private static FactorySpy<Enemy1BulletBehaviour> Enemy1BulletFactorySpy = new FactorySpy<Enemy1BulletBehaviour>();
	private static Enemy1BulletSpawner Spawner = new Enemy1BulletSpawner(Enemy1BulletFactorySpy, Enemy1BulletSettings);

	[Test]
	public void Should_CreateNewObect_WhenSpawned()
	{
		//Act
		Spawner.Spawn(Vector3.zero);
		//Assert 
		Assert.IsTrue(Enemy1BulletFactorySpy.IsCreateInvoked);
	}

	[TestCase(5, 6, 6, 5, TestName="FrogPlayerIsAtRightDown")]
	[TestCase(5, 1, 6, 2, TestName="FrogPlayerIsAtRightUp")]
	[TestCase(35, 6, 34, 5, TestName="FrogPlayerIsAtLeftDown")]
	[TestCase(35, 1, 34, 2, TestName="FrogPlayerIsAtLeftUp")]
	public void Should_HaveInitialPositionDependingOnFrogPlayerAndEnemy1_WhenSpawnedAfterEnemy1Moved(
		float enemy1X, float enemy1Y, float expectedBulletX, float expectedBulletY)
	{
		//Arrange
		var frogPlayer = TestGameObject.GetNew();
		frogPlayer.transform.position = FrogPlayerPosition;
		Spawner.OnFrogPlayerMoved(new FrogPlayerMovedSignal(frogPlayer, default));
		//Act
		var enemy1Position = new Vector3(enemy1X, enemy1Y, 0);
		Spawner.Spawn(enemy1Position);
		//Assert
		Assert.AreEqual(new Vector3(expectedBulletX, expectedBulletY, 0), Enemy1BulletFactorySpy.CreatedObject.transform.position);
	}

	[TestCase(5, 6, 6, 5, TestName="FrogPlayerIsAtRightDown")]
	[TestCase(5, 1, 6, 2, TestName="FrogPlayerIsAtRightUp")]
	[TestCase(35, 6, 34, 5, TestName="FrogPlayerIsAtLeftDown")]
	[TestCase(35, 1, 34, 2, TestName="FrogPlayerIsAtLeftUp")]
	public void Should_HaveInitialPositionDependingOnFrogPlayerAndEnemy1_WhenSpawnedAfterEnemy1Spawned(
		float enemy1X, float enemy1Y, float expectedBulletX, float expectedBulletY)
	{
		//Arrange
		var frogPlayer = TestGameObject.GetNew();
		frogPlayer.transform.position = FrogPlayerPosition;
		Spawner.OnFrogPlayerMoved(new FrogPlayerMovedSignal(frogPlayer, default));
		//Act
		var enemy1Position = new Vector3(enemy1X, enemy1Y, 0);
		Spawner.Spawn(enemy1Position);
		//Assert
		Assert.AreEqual(new Vector3(expectedBulletX, expectedBulletY, 0), Enemy1BulletFactorySpy.CreatedObject.transform.position);
	}

	[Test]
	public void Should_PointTowardsFrogPlayer_WhenSpawned()
	{
		//Arrange
		var frogPlayer = TestGameObject.GetNew();
		frogPlayer.transform.position = FrogPlayerPosition;
		//Act
		var enemy1Position = new Vector3(5, 15, 0);
		Spawner.Spawn(enemy1Position);
		//Assert
		var normalizedDirection = (frogPlayer.transform.position - enemy1Position).normalized;
		var direction2d = new Vector2(normalizedDirection.x, normalizedDirection.y);
		Assert.AreEqual(direction2d * SpeedInUnitsPerSecond, Enemy1BulletFactorySpy.CreatedObject.GetComponent<Rigidbody2D>().velocity);
	}
}