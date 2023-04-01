using NUnit.Framework;

public class FrogPlayerMoverTests
{
	[Test]
    public void Should_NotMove_WhenThereIsNoMovementKeyDown()
	{
		//Arrange
		var mover = FrogPlayerMoverTestHelper.GetMover(KeyInputStub.None);
		var rigidBody = TestRigidBody.GetNew();
		var originalVelocity = rigidBody.velocity;
		var originalX = rigidBody.position.x;
		//Act
		mover.Move(rigidBody);
		//Assert
		Assert.AreEqual(originalVelocity, rigidBody.velocity);
		Assert.AreEqual(originalX, rigidBody.position.x);
	}
}
