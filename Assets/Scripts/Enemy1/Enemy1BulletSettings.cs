using System;
using UnityEngine;

namespace FrogSurvive.Enemy1
{
	[Serializable]
	public class Enemy1BulletSettings
	{
		public Enemy1BulletSettings(float speedInUnitsPerSecond, GameObject enemy1BulletPrefab)
		{
			SpeedInUnitsPerSecond = speedInUnitsPerSecond;
			Enemy1BulletPrefab = enemy1BulletPrefab;
		}

		public GameObject Enemy1BulletPrefab;
		public float SpeedInUnitsPerSecond;
	}
}