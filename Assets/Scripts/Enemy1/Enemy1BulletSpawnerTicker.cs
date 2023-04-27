using Scripts;
using UnityEngine;
using Zenject;

namespace FrogSurvive.Enemy1
{
	public class Enemy1BulletSpawnerTicker
	{
		private readonly Enemy1BulletSpawner _enemy1BulletSpawner;
		private readonly RealTimeTicker _realTimeTicker;

		[Inject]
		public Enemy1BulletSpawnerTicker(Enemy1BulletSpawner enemy1BulletSpawner, RealTimeTicker realTimeTicker,
			Enemy1BulletSettings enemy1BulletSettings)
		{
			_enemy1BulletSpawner = enemy1BulletSpawner;
			_realTimeTicker = realTimeTicker;
			_realTimeTicker.Set(enemy1BulletSettings.SpawnIntervalInSeconds);
			_realTimeTicker.Reset();
		}

		public void Tick(Vector3 enemy1Location)
		{
			_realTimeTicker.Set(() => _enemy1BulletSpawner.Spawn(enemy1Location));
			_realTimeTicker.Tick();
		}

		public void Cancel()
		{
			_realTimeTicker.Cancel();
		}
	}
}