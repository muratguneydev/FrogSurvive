using System;
using System.Collections;
using FrogSurvive.Enemy1;
using FrogSurvive.Events;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class Enemy1BehaviourTests : ZenjectIntegrationTestFixture
{
	private bool _isEnemy1MovedEventRaised;

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
	public IEnumerator Should_RaiseEvent_WhenMoved()
	{
		//Arrange
		var setUp = SetUp();
		setUp.EventBus.Subscribe<Enemy1MovedSignal>(OnEnemy1Moved);
		//Act
		yield return new WaitForFixedUpdate();//Let it move down
		//Assert
		Assert.IsTrue(_isEnemy1MovedEventRaised);
	}

	private void OnEnemy1Moved(Enemy1MovedSignal enemy1MovedSignal)
	{
		_isEnemy1MovedEventRaised = true;
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
