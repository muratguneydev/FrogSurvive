using System.Collections;
using FrogSurvive.Enemy1;
using NUnit.Framework;
using Scripts;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class GameControllerTests : ZenjectIntegrationTestFixture
{
	[UnityTest]
	public IEnumerator ShouldSpawnEnemy1_WhenGameStarts()
	{
		//Arrange
		var setUp = SetUp();
		//Act
		yield return null;
		//Assert
		Assert.AreEqual(Constants.Enemy1GameObjectName, GameObject.FindFirstObjectByType<Enemy1Behaviour>().gameObject.name);
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