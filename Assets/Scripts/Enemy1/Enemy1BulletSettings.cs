using System;
using UnityEngine;

namespace FrogSurvive.Enemy1
{
	[Serializable]
	public class Enemy1BulletSettings
	{
		public Enemy1BulletSettings(float speedInUnitsPerSecond, GameObject enemy1BulletPrefab, float spawnIntervalInSeconds)
		{
			SpeedInUnitsPerSecond = speedInUnitsPerSecond;
			Enemy1BulletPrefab = enemy1BulletPrefab;
			SpawnIntervalInSeconds = spawnIntervalInSeconds;
		}

		public GameObject Enemy1BulletPrefab;
		public float SpeedInUnitsPerSecond;
		public float SpawnIntervalInSeconds;
	}
}