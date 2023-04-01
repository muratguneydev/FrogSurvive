using FrogSurvive.Events;
using NUnit.Framework;
using UnityEngine;

public class FrogPlayerMoverHorizontalTests
{
	[Test]
    public void Should_MoveToRight_WhenRightKeyDown()
	{
		//Arrange
		var horizontalMover = FrogPlayerMoverTestHelper.GetMover(KeyInputStub.Right);
		var rigidBody = TestRigidBody.GetNew();
		//Act
		horizontalMover.Move(rigidBody);
		//Assert
		Assert.AreEqual(Vector2.right * FrogPlayerMoverTestHelper.VelocityMoveUnitsPerSecond, rigidBody.velocity);
	}

	[Test]
    public void Should_MoveToLeft_WhenLeftKeyDown()
	{
		//Arrange
		var horizontalMover = FrogPlayerMoverTestHelper.GetMover(KeyInputStub.Left);
		var rigidBody = TestRigidBody.GetNew();
		//Act
		horizontalMover.Move(rigidBody);
		//Assert
		Assert.AreEqual(Vector2.left * FrogPlayerMoverTestHelper.VelocityMoveUnitsPerSecond, rigidBody.velocity);
	}

	[Test]
    public void Should_RaiseMoveEvent_WhenRightKeyDown()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<FrogPlayerMovedSignal>();
		var horizontalMover = FrogPlayerMoverTestHelper.GetMover(eventBusSpy, KeyInputStub.Right);
		//Act
		horizontalMover.Move(TestRigidBody.GetNew());
		//Assert
		var (isEventFired, firedEvent) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isEventFired);
		Assert.AreEqual(Vector2.right, firedEvent.Vector);
	}

	[Test]
    public void Should_RaiseMoveEvent_WhenLeftKeyDown()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<FrogPlayerMovedSignal>();
		var horizontalMover = FrogPlayerMoverTestHelper.GetMover(eventBusSpy, KeyInputStub.Left);
		//Act
		horizontalMover.Move(TestRigidBody.GetNew());
		//Assert
		var (isEventFired, firedEvent) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isEventFired);
		Assert.AreEqual(Vector2.left, firedEvent.Vector);
	}	
}
