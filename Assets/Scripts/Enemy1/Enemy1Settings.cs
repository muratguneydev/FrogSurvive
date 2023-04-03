using System;
using UnityEngine;

namespace FrogSurvive.Enemy1
{
	[Serializable]
	public class Enemy1Settings
	{
		public Enemy1Settings(int velocityInUnitsPerSecond, Vector3 spawnPosition, GameObject enemy1Prefab)
		{
			VelocityInUnitsPerSecond = velocityInUnitsPerSecond;
			SpawnPosition = spawnPosition;
			Enemy1Prefab = enemy1Prefab;
		}

		public int VelocityInUnitsPerSecond = 10;
		public Vector3 SpawnPosition;
		public GameObject Enemy1Prefab;
	}
}