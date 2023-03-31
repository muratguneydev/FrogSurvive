using System.Collections;
using FrogSurvive.FrogPlayer;
using NUnit.Framework;
using Scripts;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class FrogPlayerBehaviourTests : ZenjectIntegrationTestFixture
{
	const int FrogHorizontalVelocityUnitsPerSecond = 10;

    [UnityTest]
	public IEnumerator Should_GoRight_WhenRightArrowKeyDown()
	{
		//Arrange
		RegisterDependencies(new RightHorizontalInputStub());

		var playerBehaviour = Container.Resolve<FrogPlayerBehaviour>();
		var originalX = playerBehaviour.gameObject.transform.position.x;
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.IsTrue(playerBehaviour.gameObject.transform.position.x > originalX);
	}

	[UnityTest]
	public IEnumerator Should_GoLeft_WhenLeftArrowKeyDown()
	{
		//Arrange
		RegisterDependencies(new LeftHorizontalInputStub());
		
		var playerBehaviour = Container.Resolve<FrogPlayerBehaviour>();
		var originalX = playerBehaviour.gameObject.transform.position.x;
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.IsTrue(playerBehaviour.gameObject.transform.position.x < originalX);
	}

	[UnityTest]
	public IEnumerator Should_NotMove_WhenThereIsNoMovementKeyDown()
	{
		//Arrange
		RegisterDependencies(new NoMoveInputStub());
		
		var playerBehaviour = Container.Resolve<FrogPlayerBehaviour>();
		var originalX = playerBehaviour.gameObject.transform.position.x;
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.AreEqual(playerBehaviour.gameObject.transform.position.x, originalX);
	}

	[UnityTest]
	public IEnumerator Should_SpriteChangeDirection_WhenMoveDirectionChangedFromRightToLeft()
	{
		//Arrange
		RegisterDependencies(new LeftHorizontalInputStub());
		
		var playerBehaviour = Container.Resolve<FrogPlayerBehaviour>();
		playerBehaviour.gameObject.transform.localScale = new Vector3(2, 2, 2);
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.AreEqual(playerBehaviour.gameObject.transform.localScale, new Vector3(-2, 2, 2));
	}

	[UnityTest]
	public IEnumerator Should_SpriteChangeDirection_WhenMoveDirectionChangedFromLeftToRight()
	{
		//Arrange
		RegisterDependencies(new RightHorizontalInputStub());
		
		var playerBehaviour = Container.Resolve<FrogPlayerBehaviour>();
		playerBehaviour.gameObject.transform.localScale = new Vector3(-2, 2, 2);
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.AreEqual(playerBehaviour.gameObject.transform.localScale, new Vector3(2, 2, 2));
	}

	[UnityTest]
	public IEnumerator Should_SpriteNotChangeDirection_WhenMoveDirectionStaysRight()
	{
		//Arrange
		RegisterDependencies(new RightHorizontalInputStub());
		
		var playerBehaviour = Container.Resolve<FrogPlayerBehaviour>();
		playerBehaviour.gameObject.transform.localScale = new Vector3(2, 2, 2);
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.AreEqual(playerBehaviour.gameObject.transform.localScale, new Vector3(2, 2, 2));
	}

	[UnityTest]
	public IEnumerator Should_SpriteNotChangeDirection_WhenMoveDirectionStaysLeft()
	{
		//Arrange
		RegisterDependencies(new LeftHorizontalInputStub());
		
		var playerBehaviour = Container.Resolve<FrogPlayerBehaviour>();
		playerBehaviour.gameObject.transform.localScale = new Vector3(-2, 2, 2);
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.AreEqual(playerBehaviour.gameObject.transform.localScale, new Vector3(-2, 2, 2));
	}

	private void RegisterDependencies(KeyInput keyInput)
	{
		PreInstall();
		Container.Install<CoreInstaller>();
		FrogPlayerInstaller.Install(Container, new FrogPlayerSettings(FrogHorizontalVelocityUnitsPerSecond));
		Container.Rebind<KeyInput>().FromInstance(keyInput);//For non-interface types, rebind cannot be AsSingle.
		Container.Bind<FrogPlayerBehaviour>().FromNewComponentOnNewGameObject()
			.AsSingle();
		PostInstall();
	}
}