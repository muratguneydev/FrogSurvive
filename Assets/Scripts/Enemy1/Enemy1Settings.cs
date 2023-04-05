using System;
using Scripts;
using UnityEngine;

namespace FrogSurvive.Enemy1
{
	[Serializable]
	public class Enemy1Settings
	{
		public Enemy1Settings(Velocity velocity, Vector3 spawnPosition, GameObject enemy1Prefab)
		{
			Velocity = velocity;
			SpawnPosition = spawnPosition;
			Enemy1Prefab = enemy1Prefab;
		}

		public float VelocityInUnitsPerSecond = 10;
		public Vector3 SpawnPosition;
		public GameObject Enemy1Prefab;
		public Velocity Velocity;
	}
}