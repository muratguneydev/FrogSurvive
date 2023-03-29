using System.Collections;
using FrogSurvive.FrogPlayer;
using NUnit.Framework;
using Scripts;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class FrogPlayerBehaviourTests : ZenjectIntegrationTestFixture
{
    [UnityTest]
	public IEnumerator Should_GoRight_WhenRightArrowKeyDown()
	{
		//Arrange
		PreInstall();
		const int FrogHorizontalVelocityUnitsPerSecond = 10;
		// Container.Install<CoreInstaller>();


		// var pipePrefab = PipePrefab.Create();
		// var pipeSpawnerSettings = new PipeSpawnerSettings();
		// Container.Bind<PipeSettings>().FromInstance(pipeSettings).AsSingle();
		// Container.Bind<PipeSpawnerSettings>().FromInstance(pipeSpawnerSettings).AsSingle();
		// PipeInstaller.Install(Container, pipeSettings, pipeSpawnerSettings);

		FrogPlayerInstaller.Install(Container, new FrogPlayerSettings(FrogHorizontalVelocityUnitsPerSecond));

		var rightKeyInputStub = new KeyInputStub(1);
		Container.Rebind<KeyInput>().FromInstance(rightKeyInputStub);//For non-interface types, rebind cannot be AsSingle.
		
		
		Container.Bind<FrogPlayerBehaviour>().FromNewComponentOnNewGameObject()
			.AsSingle();
		PostInstall();
		
		var playerBehaviour = Container.Resolve<FrogPlayerBehaviour>();
		var originalX = playerBehaviour.gameObject.transform.position.x;
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.IsTrue(playerBehaviour.gameObject.transform.position.x > originalX);
	}
}