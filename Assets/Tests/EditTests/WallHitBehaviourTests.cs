using FrogSurvive.Events;
using NUnit.Framework;
using Scripts;

public class WallHitBehaviourTests
{
	[Test]
	public void Should_RaiseNonDestroyableHitTheWallEvent_WhenCollided()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<HitTheWallUISignal>();
		var wallDestroyerBehaviourWrapper = new MonoReflector<WallHitBehaviour>();
		var nonDestroyableProducingFactory = new HitTheWallUISignalFactoryStub(false);
		wallDestroyerBehaviourWrapper.MonoBehaviour.Construct(eventBusSpy, nonDestroyableProducingFactory);
		//Act
		wallDestroyerBehaviourWrapper.OnCollisionEnter2D(new Collision2DStub());
		//Assert
		var (isFired, signal) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isFired);
		Assert.IsFalse(signal.IsDestroyable);
	}

	[Test]
	public void Should_RaiseDestroyableHitTheWallEvent_WhenEnemy1BulletCollided()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<HitTheWallUISignal>();
		var wallDestroyerBehaviourWrapper = new MonoReflector<WallHitBehaviour>();
		var destroyableProducingFactory = new HitTheWallUISignalFactoryStub(true);
		wallDestroyerBehaviourWrapper.MonoBehaviour.Construct(eventBusSpy, destroyableProducingFactory);
		//Act
		var enemy1Bullet = TestGameObject.GetNew();
		enemy1Bullet.name = Constants.Enemy1GameObjectName;
		wallDestroyerBehaviourWrapper.OnCollisionEnter2D(new Collision2DStub(enemy1Bullet));
		//Assert
		var (isFired, signal) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isFired);
		Assert.IsTrue(signal.IsDestroyable);
	}
}
