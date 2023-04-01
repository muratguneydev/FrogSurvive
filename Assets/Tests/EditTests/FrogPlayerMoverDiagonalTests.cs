using NUnit.Framework;
using UnityEngine;

public class FrogPlayerMoverDiagonalTests
{
	[Test]
    public void Should_MoveDiagonal_WhenUpRightKeyDown()
	{
		//Arrange
		var mover = FrogPlayerMoverTestHelper.GetMover(KeyInputStub.UpRight);
		var rigidBody = TestRigidBody.GetNew();
		//Act
		mover.Move(rigidBody);
		//Assert
		var expectedVelocity = (Vector2.up + Vector2.right).normalized * FrogPlayerMoverTestHelper.VelocityMoveUnitsPerSecond;
		Assert.AreEqual(expectedVelocity, rigidBody.velocity);
	}

	[Test]
    public void Should_MoveDiagonal_WhenUpLeftKeyDown()
	{
		//Arrange
		var mover = FrogPlayerMoverTestHelper.GetMover(KeyInputStub.UpLeft);
		var rigidBody = TestRigidBody.GetNew();
		//Act
		mover.Move(rigidBody);
		//Assert
		var expectedVelocity = (Vector2.up + Vector2.left).normalized * FrogPlayerMoverTestHelper.VelocityMoveUnitsPerSecond;
		Assert.AreEqual(rigidBody.velocity, expectedVelocity);
	}
}