using FrogSurvive.Enemy1;
using NUnit.Framework;
using Scripts;
using UnityEngine;

public class Enemy1BulletSpawnerTests
{
	private static Velocity Velocity = new Velocity(10, Vector2.down);
	private static Enemy1BulletSettings Enemy1BulletSettings = new Enemy1BulletSettings(Velocity, new Vector3(5, 10, 0), TestGameObject.GetNew());
	private static FactorySpy<Enemy1BulletBehaviour> Enemy1BulletFactorySpy = new FactorySpy<Enemy1BulletBehaviour>();
	private static Enemy1BulletSpawner Spawner = new Enemy1BulletSpawner(Enemy1BulletFactorySpy, Enemy1BulletSettings);

	[Test]
	public void Should_CreateNewObect_WhenSpawnInvoked()
	{
		//Act
		Spawner.Spawn();
		//Assert
		Assert.IsTrue(Enemy1BulletFactorySpy.IsCreateInvoked);
	}

	[Test]
	public void Should_HaveCorrectInitialPosition_WhenSpawnInvoked()
	{
		//Act
		Spawner.Spawn();
		//Assert
		Assert.AreEqual(Enemy1BulletSettings.SpawnPosition, Enemy1BulletFactorySpy.CreatedObject.transform.position);
	}
}