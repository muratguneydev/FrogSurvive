using FrogSurvive.Enemy1;
using NUnit.Framework;
using Scripts;
using UnityEngine;

public class Enemy1SpawnerTests
{
	private static Velocity Velocity = new Velocity(10, Vector2.down);
	private static Enemy1Settings Enemy1Settings = new Enemy1Settings(Velocity, new Vector3(5, 10, 0), TestGameObject.GetNew());
	private static FactorySpy<Enemy1Behaviour> Enemy1FactorySpy = new FactorySpy<Enemy1Behaviour>();
	private static Enemy1Spawner Spawner = new Enemy1Spawner(Enemy1FactorySpy, Enemy1Settings);

	[Test]
	public void Should_CreateNewObect_WhenSpawnInvoked()
	{
		//Act
		Spawner.Spawn();
		//Assert
		Assert.IsTrue(Enemy1FactorySpy.IsCreateInvoked);
	}

	[Test]
	public void Should_HaveCorrectInitialPosition_WhenSpawnInvoked()
	{
		//Act
		Spawner.Spawn();
		//Assert
		Assert.AreEqual(Enemy1Settings.SpawnPosition, Enemy1FactorySpy.CreatedObject.transform.position);
	}
}
