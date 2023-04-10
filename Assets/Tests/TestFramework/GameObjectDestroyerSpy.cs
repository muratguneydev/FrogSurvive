using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class GameObjectDestroyerSpy : GameObjectDestroyer
{
	private readonly List<GameObject> _destroyedObjects = new List<GameObject>();
	public override void Destroy(GameObject gameObject)
	{
		_destroyedObjects.Add(gameObject);
	}

	public bool IsDestroyed(GameObject gameObject) => _destroyedObjects.Contains(gameObject);
}