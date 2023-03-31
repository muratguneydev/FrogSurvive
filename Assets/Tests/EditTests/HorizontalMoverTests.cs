using FrogSurvive.Events;
using FrogSurvive.FrogPlayer;
using NUnit.Framework;
using UnityEngine;

public class HorizontalMoverTests
{
	private const int VelocityMoveUnitsPerSecond = 10;
	private static IEventBus EventBusDummy = new EventBusDummy();
	private static Rigidbody2D RigidbodyDummy = TestRigidBody.GetNew();

	[Test]
    public void Should_MoveToRight_WhenRightKeyDown()
	{
		//Arrange
		var horizontalMover = GetMover(EventBusDummy, new RightHorizontalInputStub());
		var rigidBody = TestRigidBody.GetNew();
		//Act
		horizontalMover.Move(rigidBody);
		//Assert
		Assert.AreEqual(rigidBody.velocity, Vector2.right * VelocityMoveUnitsPerSecond);
	}

	[Test]
    public void Should_MoveToLeft_WhenLeftKeyDown()
	{
		//Arrange
		var horizontalMover = GetMover(EventBusDummy, new LeftHorizontalInputStub());
		var rigidBody = TestRigidBody.GetNew();
		//Act
		horizontalMover.Move(rigidBody);
		//Assert
		Assert.AreEqual(rigidBody.velocity, Vector2.left * VelocityMoveUnitsPerSecond);
	}

	[Test]
    public void Should_NotMove_WhenThereIsNoMovementKeyDown()
	{
		//Arrange
		var horizontalMover = GetMover(EventBusDummy, new NoMoveInputStub());
		var rigidBody = TestRigidBody.GetNew();
		var originalVelocity = rigidBody.velocity;
		var originalX = rigidBody.position.x;
		//Act
		horizontalMover.Move(rigidBody);
		//Assert
		Assert.AreEqual(originalVelocity, rigidBody.velocity);
		Assert.AreEqual(originalX, rigidBody.position.x);
	}

	[Test]
    public void Should_RaiseMoveEvent_WhenRightKeyDown()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<FrogPlayerMovedSignal>();
		var horizontalMover = GetMover(eventBusSpy, new RightHorizontalInputStub());
		//Act
		horizontalMover.Move(RigidbodyDummy);
		//Assert
		var (isEventFired, firedEvent) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isEventFired);
		Assert.AreEqual(Vector2.right.normalized, firedEvent.Vector);
	}

	[Test]
    public void Should_RaiseMoveEvent_WhenLeftKeyDown()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<FrogPlayerMovedSignal>();
		var horizontalMover = GetMover(eventBusSpy, new LeftHorizontalInputStub());
		//Act
		horizontalMover.Move(RigidbodyDummy);
		//Assert
		var (isEventFired, firedEvent) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isEventFired);
		Assert.AreEqual(Vector2.left.normalized, firedEvent.Vector);
	}

	private static HorizontalMover GetMover(IEventBus eventBus, KeyInputStub keyInputStub)
		=> new HorizontalMover(eventBus, keyInputStub, VelocityMoveUnitsPerSecond);
}
