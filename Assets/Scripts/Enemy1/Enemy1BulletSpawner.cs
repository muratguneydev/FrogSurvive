using System;
using FrogSurvive.Events;
using UnityEngine;
using Zenject;

namespace FrogSurvive.Enemy1
{
	public class Enemy1BulletSpawner
	{
		private readonly IFactory<Enemy1BulletBehaviour> _enemy1BulletFactory;
		private readonly Enemy1BulletSettings _enemy1BulletSettings;
		private Vector3 _currentEnemy1Position;

		public Enemy1BulletSpawner(IFactory<Enemy1BulletBehaviour> enemy1BulletFactory, Enemy1BulletSettings enemy1BulletSettings)
		{
			_enemy1BulletFactory = enemy1BulletFactory;
			_enemy1BulletSettings = enemy1BulletSettings;
		}

		public void OnEnemy1Moved(Enemy1MovedSignal enemy1MovedSignal)
		{
			_currentEnemy1Position = enemy1MovedSignal.Enemy1.transform.position;
		}

		public void OnEnemy1Spawned(Enemy1SpawnedSignal enemy1SpawnedSignal)
		{
			_currentEnemy1Position = enemy1SpawnedSignal.Enemy1.transform.position;
		}

		public virtual void Spawn()
		{
			var enemy1BulletBehaviour = _enemy1BulletFactory.Create();
			Debug.Log(_currentEnemy1Position);
			enemy1BulletBehaviour.gameObject.transform.position = _currentEnemy1Position - new Vector3(0, 1, 0);
			Debug.Log(enemy1BulletBehaviour.gameObject.transform.position);

		}
	}
}