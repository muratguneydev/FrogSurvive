using UnityEngine;

namespace FrogSurvive.Events
{
	public class Enemy1SpawnedSignal
	{
		public Enemy1SpawnedSignal(GameObject enemy1)
		{
			Enemy1 = enemy1;
		}

		public GameObject Enemy1 { get; }
	}
}