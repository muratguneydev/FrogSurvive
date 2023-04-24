using System.Collections;
using FrogSurvive.Events;
using NUnit.Framework;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;

public class GameOverBehaviourTests : ZenjectIntegrationTestFixture
{
	// private bool _sceneLoaded;

	// [OneTimeSetUp]
	// public void OneTimeSetup()
	// {
	// 	SceneManager.sceneLoaded += OnSceneLoaded;
	// 	SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
	// }

	// void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	// {
	// 	_sceneLoaded = true;
	// }

	[UnityTest]
	public IEnumerator ShouldShowGameOverScreen_WhenFrogPlayerDiedEventReceived()
	{
		//Arrange
		var setUp = SetUp();

		setUp.GameOverGameObject.SetActive(false);

		var eventBus = Container.Resolve<IEventBus>();
		//Act
		eventBus.Fire(new FrogPlayerDiedSignal(setUp.FrogPlayerGameObject));
		//Assert
		Assert.IsTrue(setUp.GameOverGameObject.activeSelf);
		yield return null;
	}

	// [UnityTest]
	// public IEnumerator ShouldDisableGameOverScreen_WhenGameStarted()
	// {
	// 	var setUp = SetUp();
	// 	yield return new WaitWhile(() => _sceneLoaded == false);
	// 	Assert.IsFalse(setUp.GameOverGameObject.activeSelf);
	// 	//Add all other references as well for quick nullref testing
	// 	yield return null;
	// }

	// [UnityTest]
	// public IEnumerator ShouldDisableGameOverScreen_WhenGameStarted()
	// {
	// 	//Arrange
	// 	var setUp = SetUp();
	// 	//Assert
	// 	Assert.IsFalse(setUp.GameOverGameObject.activeSelf);
	// 	yield return null;
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