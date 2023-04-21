using Zenject;

public class Enemy1BulletBehaviourTests : ZenjectIntegrationTestFixture
{
    // [UnityTest]
	// public IEnumerator Should_MoveDown_WhenCreated()
	// {
	// 	//Arrange
	// 	var setUp = SetUp();
	// 	var enemy1BulletGameObject = GameObject.FindFirstObjectByType<Enemy1BulletBehaviour>().gameObject;
	// 	var originalY = enemy1BulletGameObject.transform.position.y;
	// 	//Act
	// 	yield return new WaitForSeconds(1.0f);//Let it move down around 10 units in 1 second.
	// 	//Assert
	// 	Assert.IsTrue(enemy1BulletGameObject.transform.position.y < originalY);
	// }

	private TestDependencyInstaller SetUp()
	{
		PreInstall();
		var setUp = new TestDependencyInstaller(Container, KeyInputStub.None);
		setUp.Install();
		PostInstall();

		return setUp;
	}
}
