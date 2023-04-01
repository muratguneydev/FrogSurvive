using System.Collections;
using NUnit.Framework;
using Scripts;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class FrogPlayerAnimatorTests : ZenjectIntegrationTestFixture
{
	[UnityTest]
	public IEnumerator Should_ActivateVerticalMoveAnimation_WhenMovingUp()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Up);
		//Act
		yield return null;
		//Assert
		Assert.IsTrue(setUp.GameObject.GetComponent<Animator>().GetBool("isPlayerMovingVertically"));
	}

	[UnityTest]
	public IEnumerator Should_ActivateVerticalMoveAnimation_WhenMovingDown()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Down);
		//Act
		yield return null;
		//Assert
		Assert.IsTrue(setUp.GameObject.GetComponent<Animator>().GetBool("isPlayerMovingVertically"));
	}

	[UnityTest]
	public IEnumerator Should_ActivateHorizontalMoveAnimation_WhenMovingRight()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Right);
		//Act
		yield return null;
		//Assert
		Assert.IsTrue(setUp.GameObject.GetComponent<Animator>().GetBool("isPlayerMovingHorizontally"));
	}

	[UnityTest]
	public IEnumerator Should_ActivateHorizontalMoveAnimation_WhenMovingLeft()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Left);
		//Act
		yield return null;
		//Assert
		Assert.IsTrue(setUp.GameObject.GetComponent<Animator>().GetBool("isPlayerMovingHorizontally"));
	}

	private FrogPlayerTestSetUp SetUp(KeyInput keyInput)
	{
		PreInstall();
		var setUp = new FrogPlayerTestSetUp(Container, keyInput);
		setUp.SetUp();
		PostInstall();

		return setUp;
	}
}