using FrogSurvive.Enemy1;
using NUnit.Framework;
using UnityEngine;
using Zenject;

public class Enemy1SpawnerTests
{
	[Test]
	public void Should_CreateNewObect_WhenSpawnInvoked()
	{
		var enemy1FactorySpy = new Enemy1FactorySpy();
		var enemy1Settings = new Enemy1Settings(10, new Vector3(5, 10, 0), TestGameObject.GetNew());
		var spawner = GetEnemy1Spawner(enemy1FactorySpy, enemy1Settings);
		spawner.Invoke();

		Assert.IsTrue(enemy1FactorySpy.IsCreateInvoked);
	}

	[Test]
	public void Should_HaveCorrectInitialPosition_WhenSpawnInvoked()
	{
		var enemy1FactorySpy = new Enemy1FactorySpy();
		var enemy1Settings = new Enemy1Settings(10, new Vector3(5, 10, 0), TestGameObject.GetNew());
		var spawner = GetEnemy1Spawner(enemy1FactorySpy, enemy1Settings);
		spawner.Invoke();

		Assert.IsTrue(enemy1FactorySpy.CreatedObject.transform.position == enemy1Settings.SpawnPosition);
	}

	private static Enemy1Spawner GetEnemy1Spawner(IFactory<Enemy1Behaviour> enemy1Factory, Enemy1Settings enemy1Settings)
	{
		return new Enemy1Spawner(enemy1Factory, enemy1Settings);
	}

	// private class SpawnedTestEnemy1
	// {
	// 	public SpawnedTestEnemy1(float expectedYPosition)
	// 	{
	// 		ExpectedYPosition = expectedYPosition;

	// 		//var gameObject = new GameObject();
	// 		Pipe = TestGameObject.GetNew().AddComponent<TestPipe>();
	// 	}

	// 	public float ExpectedYPosition { get; }
	// 	public TestPipe Pipe { get; }

	// 	public void AssertYPosition()
	// 	{
	// 		Assert.AreEqual(ExpectedYPosition, Pipe.transform.position.y);
	// 	}
	// }

	// public class TestPipe : PipeBehaviour
	// {

	// }

	
}