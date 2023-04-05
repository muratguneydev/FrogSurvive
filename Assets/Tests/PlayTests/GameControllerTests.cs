using System.Collections;
using System.Linq;
using FrogSurvive.Enemy1;
using NUnit.Framework;
using Scripts;
using UnityEditor;
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
		//yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.;
		//Assert
		//Assert.IsTrue(Resources.FindObjectsOfTypeAll<Enemy1Behaviour>().Count() == 1);
		//Assert.IsTrue(GameObject.FindFirstObjectByType<Enemy1Behaviour>() != null);
		
		//Debug.Log(GameObject.FindFirstObjectByType<Enemy1Behaviour>().gameObject.transform.position);
		//Debug.Log(GameObject.FindFirstObjectByType<Enemy1Behaviour>().gameObject.name);

		Assert.AreEqual(Enemy1Installer.Enemy1GameObjectName, GameObject.FindFirstObjectByType<Enemy1Behaviour>().gameObject.name);
		
		//Debug.Log(JsonUtility.ToJson(GameObject.FindFirstObjectByType<Enemy1Behaviour>()));
		//Assert.IsTrue(Resources.FindObjectsOfTypeAll<Enemy1Behaviour>().Single().gameObject.scene);
		//Assert.IsTrue(Resources.FindObjectsOfTypeAll<Enemy1Behaviour>().First(x => x.gameObject.activeSelf));
		
	}

	private static Enemy1Settings GetEnemy1Settings()
	{
		var enemy1Prefab = TestGameObject.GetNew();
		enemy1Prefab.AddComponent<Enemy1Behaviour>();
		var enemy1Settings = new Enemy1Settings(new Velocity(10, Vector2.down), Vector3.zero, enemy1Prefab);
		return enemy1Settings;
	}

	private TestDependencyInstaller SetUp()
	{
		PreInstall();
		var setUp = new TestDependencyInstaller(Container, KeyInputStub.None, GetEnemy1Settings());
		setUp.Install();
		PostInstall();

		return setUp;
	}
}