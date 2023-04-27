using FrogSurvive.Events;
using Scripts;
using UnityEngine;
using Zenject;

namespace FrogSurvive.Enemy1
{
	public class Enemy1BulletSpawner
	{
		private readonly IFactory<Enemy1BulletBehaviour> _enemy1BulletFactory;
		private readonly Enemy1BulletSettings _enemy1BulletSettings;
		private Vector3 _currentFrogPlayerPosition = new Vector3(-2.25f, -5.45f, 0);

		public Enemy1BulletSpawner(IFactory<Enemy1BulletBehaviour> enemy1BulletFactory, Enemy1BulletSettings enemy1BulletSettings)
		{
			_enemy1BulletFactory = enemy1BulletFactory;
			_enemy1BulletSettings = enemy1BulletSettings;
		}

		public void OnFrogPlayerMoved(FrogPlayerMovedSignal frogPlayerMovedSignal)
		{
			_currentFrogPlayerPosition = frogPlayerMovedSignal.FrogPlayer.transform.position;
		}

		public virtual void Spawn(Vector3 enemy1Position)
		{
			//Debug.Log("Spawned bullet...");
			var enemy1BulletBehaviour = _enemy1BulletFactory.Create();
			enemy1BulletBehaviour.gameObject.transform.position = GetBulletSpawnPosition(enemy1Position);

			var enemy1ToFrogDirection3d = (_currentFrogPlayerPosition - enemy1Position).normalized;
			enemy1BulletBehaviour.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(enemy1ToFrogDirection3d.x, enemy1ToFrogDirection3d.y) * _enemy1BulletSettings.SpeedInUnitsPerSecond;
		}

		private Vector3 GetBulletSpawnPosition(Vector3 enemy1Position)
		{
			var x = _currentFrogPlayerPosition.x < enemy1Position.x ? enemy1Position.x - 1 : enemy1Position.x + 1;
			var y = _currentFrogPlayerPosition.y < enemy1Position.y ? enemy1Position.y - 1 : enemy1Position.y + 1;

			return new Vector3(x, y, 0);
		}
	}
}