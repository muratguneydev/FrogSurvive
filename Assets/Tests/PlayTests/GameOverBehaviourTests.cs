using System.Collections;
using FrogSurvive.Events;
using NUnit.Framework;
using Scripts;
using UnityEngine.TestTools;
using Zenject;

public class GameOverBehaviourTests : ZenjectIntegrationTestFixture
{
	[UnityTest]
	public IEnumerator ShouldShowGameOverScreen_WhenFrogPlayerDiedEventReceived()
	{
		//Arrange
		var setUp = SetUp();

		var gameOverBehaviour = Container.Resolve<GameOverBehaviour>();
		gameOverBehaviour.gameObject.SetActive(false);

		var eventBus = Container.Resolve<IEventBus>();
		//Act
		eventBus.Fire(new FrogPlayerDiedSignal(null));
		//Assert
		Assert.IsTrue(gameOverBehaviour.gameObject.activeSelf);
		yield return null;
	}

	private TestDependencyInstaller SetUp()
	{
		PreInstall();
		var setUp = new TestDependencyInstaller(Container);
		setUp.Install();
		PostInstall();

		return setUp;
	}
}