using UnityEditor;
using UnityEngine;

public static class PrefabFactory
{
	public static GameObject Enemy1 => Get(nameof(Enemy1));
	public static GameObject Enemy1Bullet => Get(nameof(Enemy1Bullet));

	private static GameObject Get(string name)
	{
		return AssetDatabase.LoadAssetAtPath<GameObject>($"Assets/Prefabs/{name}.prefab");
	}
}