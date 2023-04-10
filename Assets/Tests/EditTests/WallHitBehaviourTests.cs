using FrogSurvive.Events;
using NUnit.Framework;
using Scripts;

public class WallHitBehaviourTests
{
	[Test]
	public void Should_RaiseHitTheWallEvent_WhenCollided()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<HitTheWallUISignal>();
		var wallDestroyerBehaviourWrapper = new MonoReflector<WallHitBehaviour>();
		wallDestroyerBehaviourWrapper.MonoBehaviour.Construct(eventBusSpy);
		//Act
		wallDestroyerBehaviourWrapper.OnCollisionEnter2D(new Collision2DStub());
		//Assert
		var (isFired, _) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isFired);
	}
}
