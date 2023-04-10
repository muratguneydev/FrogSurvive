using NUnit.Framework;
using Scripts;

public class HitTheWallUISignalFactoryTests
{
	[TestCase(Constants.Enemy1BulletGameObjectName, true)]
	[TestCase("any other game object name", false)]
	public void ShouldProduceEventWithDestroyableObject(string objectName, bool expectedDestroyableFlag)
	{
		//Arrange
		var factory = new HitTheWallUISignalFactory();
		var gameObject = TestGameObject.GetNew();
		gameObject.name = objectName;
		//Assert
		Assert.AreEqual(expectedDestroyableFlag, factory.Get(gameObject).IsDestroyable);
	}
}