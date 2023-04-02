using FrogSurvive.Enemy1;
using Zenject;

public class Enemy1FactorySpy : IFactory<Enemy1Behaviour>
{
	// private readonly PipeBehaviour[] _pipesToReturn;
	// private int _currentEnemy1Index;
	// public Enemy1FactorySpy()//Enemy1Behaviour[] pipesToReturn)
	// {
	// 	_pipesToReturn = pipesToReturn;
	// }


	public Enemy1Behaviour Create()
	{
		IsCreateInvoked = true;
		CreatedObject = TestGameObject.GetNew().AddComponent<Enemy1Behaviour>();
		return CreatedObject;
	}

	public bool IsCreateInvoked { get; private set; }
	public Enemy1Behaviour CreatedObject { get; private set; }

	// private static GameObject GetPipePrefab()
	// {
	// 	return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Pipe.prefab");
	// 	//var prefabInstance = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
	// }
}