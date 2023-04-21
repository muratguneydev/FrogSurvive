using System.Collections;
using FrogSurvive.Enemy1;
using NUnit.Framework;
using Scripts;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class GameControllerTests : ZenjectIntegrationTestFixture
{
	// private static readonly GameObject GameOverScreen = TestGameObject.GetNew();
	// private static readonly GameSettings GameSettings = new GameSettingsStub(GameOverScreen);
	// private static readonly GameController GameController = new GameController(Enemy1SpawnerSpy, GameObjectDestroyerSpy, GameSettings);

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

	// [UnityTest]
	// public IEnumerator ShouldShowGameOverScreen_WhenFrogPlayerDiedEventReceived()
	// {
	// 	//Arrange
	// 	var setUp = SetUp();
	// 	//var gameOverScreen = TestGameObject.GetNew();
	// 	//var 
	// 	//var gameSettings = new GameSettingsStub(gameOverScreen);
	// 	//var setUp = SetUp(gameSettings);
	// 	//GameSettings.GameOverScreen.SetActive(false);
	// 	//Act
	// 	yield return null;
	// 	setUp.GameController.OnFrogPlayerDied(new FrogPlayerDiedSignal(frogPlayer: TestGameObject.GetNew()));
	// 	//Assert
	// 	Assert.IsTrue(setUp.GameSettings.GameOverScreen.activeSelf);
		
	// }

	private TestDependencyInstaller SetUp()
	{
		PreInstall();
		var setUp = new TestDependencyInstaller(Container);
		setUp.Install();
		PostInstall();

		return setUp;
	}
}
