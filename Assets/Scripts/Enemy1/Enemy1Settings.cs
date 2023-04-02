using System;
using UnityEngine;

namespace FrogSurvive.Enemy1
{
	[Serializable]
	public class Enemy1Settings
	{
		public Enemy1Settings(int velocityInUnitsPerSecond, Vector3 spawnPosition)
		{
			VelocityInUnitsPerSecond = velocityInUnitsPerSecond;
			SpawnPosition = spawnPosition;
		}

		public int VelocityInUnitsPerSecond = 10;
		public Vector3 SpawnPosition;
		public GameObject Enemy1Prefab;
	}
}