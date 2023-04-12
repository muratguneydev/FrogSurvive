using FrogSurvive.Events;
using FrogSurvive.FrogPlayer;
using NUnit.Framework;
using Scripts;

public class FrogPlayerHealthManagerTests
{
	[Test]
	public void ShouldHave100PercentHealth_WhenStarted()
	{
		//Act
		var frogPlayerHealthManager = new FrogPlayerHealthManager(new EventBusDummy());
		//Assert
		Assert.AreEqual(100, frogPlayerHealthManager.RemainingHealth);
	}

	[Test]
	public void ShouldRemove20PercentHealth_WhenHitByABullet()
	{
		//Arrange
		var frogPlayerHealthManager = new FrogPlayerHealthManager(new EventBusDummy());
		var gameObjectHit = TestGameObject.GetNew(Constants.Enemy1BulletGameObjectName);
		//Act
		frogPlayerHealthManager.OnHitByAnObject(new FrogPlayerHitUISignal(gameObjectHit));
		//Assert
		Assert.AreEqual(80, frogPlayerHealthManager.RemainingHealth);

		//Act
		frogPlayerHealthManager.OnHitByAnObject(new FrogPlayerHitUISignal(gameObjectHit));
		//Assert
		Assert.AreEqual(60, frogPlayerHealthManager.RemainingHealth);
	}

	[Test]
	public void ShouldNotRemoveHealth_WhenHitByANonBullet()
	{
		//Arrange
		var frogPlayerHealthManager = new FrogPlayerHealthManager(new EventBusDummy());
		var gameObjectHit = TestGameObject.GetNew();
		//Act
		frogPlayerHealthManager.OnHitByAnObject(new FrogPlayerHitUISignal(gameObjectHit));
		//Assert
		Assert.AreEqual(100, frogPlayerHealthManager.RemainingHealth);
	}

	[Test]
	public void ShouldRaiseFrogPlayerDiedEvent_WhenHealthBecomes0()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<FrogPlayerDiedSignal>();
		var frogPlayerHealthManager = new FrogPlayerHealthManager(eventBusSpy);
		var gameObjectHit = TestGameObject.GetNew(Constants.Enemy1BulletGameObjectName);
		//Act
		var hittingObject = new FrogPlayerHitUISignal(gameObjectHit);
		frogPlayerHealthManager.OnHitByAnObject(hittingObject);
		frogPlayerHealthManager.OnHitByAnObject(hittingObject);
		frogPlayerHealthManager.OnHitByAnObject(hittingObject);
		frogPlayerHealthManager.OnHitByAnObject(hittingObject);
		frogPlayerHealthManager.OnHitByAnObject(hittingObject);
		//Assert
		var (isFired, signal) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isFired);
	}
}