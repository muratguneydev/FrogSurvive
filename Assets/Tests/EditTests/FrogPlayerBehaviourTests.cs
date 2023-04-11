using FrogSurvive.Events;
using FrogSurvive.FrogPlayer;
using NUnit.Framework;
using Scripts;

public class FrogPlayerBehaviourTests
{
	[Test]
	public void ShouldRaiseFrogPlayerHitEvent_WhenCollided()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<FrogPlayerHitUISignal>();
		var frogPlayerBehaviourWrapper = new MonoReflector<FrogPlayerBehaviour>();
		frogPlayerBehaviourWrapper.MonoBehaviour.Construct(eventBusSpy, TestFrogPlayerMover.GetNew());
		
		var enemy1Bullet = TestGameObject.GetNew();
		enemy1Bullet.name = Constants.Enemy1GameObjectName;
		//Act
		frogPlayerBehaviourWrapper.OnCollisionEnter2D(new Collision2DStub(enemy1Bullet));
		//Assert
		var (isFired, signal) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isFired);
		Assert.AreEqual(Constants.Enemy1GameObjectName, signal.HittingObject.name);
	}
}