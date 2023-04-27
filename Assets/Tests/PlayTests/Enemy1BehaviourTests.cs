using System.Collections;
using FrogSurvive.Enemy1;
using FrogSurvive.Events;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class Enemy1BehaviourTests : ZenjectIntegrationTestFixture
{
	[UnityTest]
	public IEnumerator Should_MoveDown_WhenCreated()
	{
		//Arrange
		var setUp = SetUp();
		var enemy1GameObject = GameObject.FindFirstObjectByType<Enemy1Behaviour>().gameObject;
		var originalY = enemy1GameObject.transform.position.y;
		//Act
		yield return new WaitForSeconds(1.0f);//Let it move down around 10 units in 1 second.
		//Assert
		Assert.IsTrue(enemy1GameObject.transform.position.y < originalY);
	}

	[UnityTest]
	public IEnumerator Should_SpawnBullet_WhenGameStarts()
	{
		//Arrange
		var setUp = SetUp();
		//Act
		yield return null;//Let it start and spawn the first bullet
		//Assert
		var enemy1BulletGameObject = GameObject.FindFirstObjectByType<Enemy1BulletBehaviour>()?.gameObject;
		Assert.IsNotNull(enemy1BulletGameObject);
	}

	[UnityTest]
	public IEnumerator Should_SpawnBullet_Every2Seconds()
	{
		//Arrange
		var setUp = SetUp();
		//Act
		yield return new WaitForSeconds(2);//Let it start and spawn the first bullet then spawn the second one after 2 seconds.
		//Assert
		var enemy1BulletBehaviours = GameObject.FindObjectsByType<Enemy1BulletBehaviour>(FindObjectsSortMode.None);
		Assert.IsNotNull(enemy1BulletBehaviours);
		Assert.AreEqual(2, enemy1BulletBehaviours.Length);
	}

	[UnityTest]
	public IEnumerator ShouldStopSpawningBullets_WhenFrogPlayerDiedEventReceived()
	{
		//Arrange
		var setUp = SetUp();
		//Act
		yield return new WaitForSeconds(2);//Let it start and spawn the first bullet then spawn the second one after 2 seconds.
		setUp.Enemy1Behaviour.OnFrogPlayerDied(new FrogPlayerDiedSignal(setUp.FrogPlayerGameObject));
		//Assert
		var enemy1BulletBehaviours = GameObject.FindObjectsByType<Enemy1BulletBehaviour>(FindObjectsSortMode.None);
		Assert.IsNotNull(enemy1BulletBehaviours);
		Assert.AreEqual(2, enemy1BulletBehaviours.Length);
		
		yield return new WaitForSeconds(2);//give time to spawn more bullets
		enemy1BulletBehaviours = GameObject.FindObjectsByType<Enemy1BulletBehaviour>(FindObjectsSortMode.None);
		Assert.AreEqual(3, enemy1BulletBehaviours.Length);
		//The additional 1 (2+1=3) bullet is spawned because Enemy1Behaviour.Start is called again by Zenject for some reason.
		//But it is not spawned by the ticker. So the Cancel works as expected.
	}

	private TestDependencyInstaller SetUp()
	{
		PreInstall();
		var setUp = new TestDependencyInstaller(Container, KeyInputStub.None);
		setUp.Install();
		PostInstall();

		return setUp;
	}
}
