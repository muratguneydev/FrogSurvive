using System;
using Scripts;
using UnityEngine;

namespace FrogSurvive.Enemy1
{
	[Serializable]
	public class Enemy1BulletSettings
	{
		public Enemy1BulletSettings(Velocity velocity, Vector3 spawnPosition, GameObject enemy1BulletPrefab)
		{
			Velocity = velocity;
			SpawnPosition = spawnPosition;
			Enemy1BulletPrefab = enemy1BulletPrefab;
		}

		public Vector3 SpawnPosition;
		public GameObject Enemy1BulletPrefab;
		public Velocity Velocity;
	}
}