using FrogSurvive.Events;
using NUnit.Framework;
using UnityEngine;

public class FrogPlayerMoverVerticalTests
{
	[Test]
    public void Should_MoveUp_WhenUpKeyDown()
	{
		//Arrange
		var horizontalMover = FrogPlayerMoverTestHelper.GetMover(KeyInputStub.Up);
		var rigidBody = TestRigidBody.GetNew();
		//Act
		horizontalMover.Move(rigidBody);
		//Assert
		Assert.AreEqual(Vector2.up * FrogPlayerMoverTestHelper.VelocityMoveUnitsPerSecond, rigidBody.velocity);
	}

	[Test]
    public void Should_MoveDown_WhenDownKeyDown()
	{
		//Arrange
		var horizontalMover = FrogPlayerMoverTestHelper.GetMover(KeyInputStub.Down);
		var rigidBody = TestRigidBody.GetNew();
		//Act
		horizontalMover.Move(rigidBody);
		//Assert
		Assert.AreEqual(Vector2.down * FrogPlayerMoverTestHelper.VelocityMoveUnitsPerSecond, rigidBody.velocity);
	}

	[Test]
    public void Should_RaiseMoveEvent_WhenUpKeyDown()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<FrogPlayerMovedSignal>();
		var horizontalMover = FrogPlayerMoverTestHelper.GetMover(eventBusSpy, KeyInputStub.Up);
		//Act
		horizontalMover.Move(TestRigidBody.GetNew());
		//Assert
		var (isEventFired, firedEvent) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isEventFired);
		Assert.AreEqual(Vector2.up, firedEvent.Vector);
	}

	[Test]
    public void Should_RaiseMoveEvent_WhenDownKeyDown()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<FrogPlayerMovedSignal>();
		var horizontalMover = FrogPlayerMoverTestHelper.GetMover(eventBusSpy, KeyInputStub.Down);
		//Act
		horizontalMover.Move(TestRigidBody.GetNew());
		//Assert
		var (isEventFired, firedEvent) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isEventFired);
		Assert.AreEqual(Vector2.down, firedEvent.Vector);
	}
}
