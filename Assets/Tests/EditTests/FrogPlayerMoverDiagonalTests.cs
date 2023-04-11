using NUnit.Framework;
using UnityEngine;

public class FrogPlayerMoverDiagonalTests
{
	[Test]
    public void Should_MoveDiagonal_WhenUpRightKeyDown()
	{
		//Arrange
		var mover = TestFrogPlayerMover.GetNew(KeyInputStub.UpRight);
		var rigidBody = TestRigidBody.GetNew();
		//Act
		mover.Move(rigidBody);
		//Assert
		var expectedVelocity = (Vector2.up + Vector2.right).normalized * TestFrogPlayerMover.VelocityMoveUnitsPerSecond;
		Assert.AreEqual(expectedVelocity, rigidBody.velocity);
	}

	[Test]
    public void Should_MoveDiagonal_WhenUpLeftKeyDown()
	{
		//Arrange
		var mover = TestFrogPlayerMover.GetNew(KeyInputStub.UpLeft);
		var rigidBody = TestRigidBody.GetNew();
		//Act
		mover.Move(rigidBody);
		//Assert
		var expectedVelocity = (Vector2.up + Vector2.left).normalized * TestFrogPlayerMover.VelocityMoveUnitsPerSecond;
		Assert.AreEqual(rigidBody.velocity, expectedVelocity);
	}
}