using System.Collections;
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
		var setUp = SetUp(KeyInputStub.Right);
		var originalX = setUp.FrogPlayerGameObject.transform.position.x;
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.IsTrue(setUp.FrogPlayerGameObject.transform.position.x > originalX);
	}

	[UnityTest]
	public IEnumerator Should_GoLeft_WhenLeftArrowKeyDown()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Left);
		var originalX = setUp.FrogPlayerGameObject.transform.position.x;
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.IsTrue(setUp.FrogPlayerGameObject.transform.position.x < originalX);
	}

	[UnityTest]
	public IEnumerator Should_NotMove_WhenThereIsNoMovementKeyDown()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.None);
		var originalX = setUp.FrogPlayerGameObject.transform.position.x;
		//Act
		yield return null;
		//Assert
		Assert.AreEqual(setUp.FrogPlayerGameObject.transform.position.x, originalX);
	}

	[UnityTest]
	public IEnumerator Should_SpriteChangeDirection_WhenMoveDirectionChangedFromRightToLeft()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Left);
		setUp.FrogPlayerGameObject.transform.localScale = new Vector3(2, 2, 2);
		//Act
		yield return null;
		//Assert
		Assert.AreEqual(setUp.FrogPlayerGameObject.transform.localScale, new Vector3(-2, 2, 2));
	}

	[UnityTest]
	public IEnumerator Should_SpriteChangeDirection_WhenMoveDirectionChangedFromLeftToRight()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Right);
		setUp.FrogPlayerGameObject.transform.localScale = new Vector3(-2, 2, 2);
		//Act
		yield return null;
		//Assert
		Assert.AreEqual(setUp.FrogPlayerGameObject.transform.localScale, new Vector3(2, 2, 2));
	}

	[UnityTest]
	public IEnumerator Should_SpriteNotChangeDirection_WhenMoveDirectionStaysRight()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Right);
		setUp.FrogPlayerGameObject.transform.localScale = new Vector3(2, 2, 2);
		//Act
		yield return null;
		//Assert
		Assert.AreEqual(setUp.FrogPlayerGameObject.transform.localScale, new Vector3(2, 2, 2));
	}

	[UnityTest]
	public IEnumerator Should_SpriteNotChangeDirection_WhenMoveDirectionStaysLeft()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Left);
		setUp.FrogPlayerGameObject.transform.localScale = new Vector3(-2, 2, 2);
		//Act
		yield return null;
		//Assert
		Assert.AreEqual(setUp.FrogPlayerGameObject.transform.localScale, new Vector3(-2, 2, 2));
	}

	private TestDependencyInstaller SetUp(KeyInput keyInput)
	{
		PreInstall();
		var setUp = new TestDependencyInstaller(Container, keyInput);
		setUp.Install();
		PostInstall();

		return setUp;
	}
}
