using FrogSurvive.Enemy1;
using FrogSurvive.Events;
using NUnit.Framework;
using Scripts;
using UnityEngine;

public class Enemy1BulletSpawnerTests
{
	private static Velocity Velocity = new Velocity(10, Vector2.down);
	private static Enemy1BulletSettings Enemy1BulletSettings = new Enemy1BulletSettings(Velocity, TestGameObject.GetNew());
	private static FactorySpy<Enemy1BulletBehaviour> Enemy1BulletFactorySpy = new FactorySpy<Enemy1BulletBehaviour>();
	private static Enemy1BulletSpawner Spawner = new Enemy1BulletSpawner(Enemy1BulletFactorySpy, Enemy1BulletSettings);

	[Test]
	public void Should_CreateNewObect_WhenSpawned()
	{
		//Act
		Spawner.Spawn();
		//Assert 
		Assert.IsTrue(Enemy1BulletFactorySpy.IsCreateInvoked);
	}

	[Test]
	public void Should_HaveInitialPosition1PointDownFromEnemy1_WhenSpawnedAfterEnemy1Moved()
	{
		//Act
		var enemy1 = TestGameObject.GetNew();
		enemy1.transform.position = new Vector3(5, 6, 0);
		Spawner.OnEnemy1Moved(new Enemy1MovedSignal(enemy1));
		Spawner.Spawn();
		//Assert
		Assert.AreEqual(new Vector3(5, 5, 0), Enemy1BulletFactorySpy.CreatedObject.transform.position);
	}

	[Test]
	public void Should_HaveInitialPosition1PointDownFromEnemy1_WhenSpawnedAfterEnemy1Spawned()
	{
		//Act
		var enemy1 = TestGameObject.GetNew();
		enemy1.transform.position = new Vector3(5, 6, 0);
		Spawner.OnEnemy1Spawned(new Enemy1SpawnedSignal(enemy1));
		Spawner.Spawn();
		//Assert
		Assert.AreEqual(new Vector3(5, 5, 0), Enemy1BulletFactorySpy.CreatedObject.transform.position);
	}
}