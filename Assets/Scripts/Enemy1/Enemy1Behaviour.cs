using FrogSurvive.Events;
using UnityEngine;
using Zenject;

namespace FrogSurvive.Enemy1
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Enemy1Behaviour : MonoBehaviour
	{
		private Enemy1Settings _enemy1Settings;
		private Enemy1BulletSpawnerTicker _bulletSpawnTicker;
		private Enemy1BulletSpawner _enemy1BulletSpawner;

		[Inject]
        public void Construct(IEventBus eventBus, Enemy1Settings enemy1Settings, Enemy1BulletSpawner enemy1BulletSpawner,
			Enemy1BulletSpawnerTicker bulletSpawnTicker)
        {
			_enemy1Settings = enemy1Settings;
			_bulletSpawnTicker = bulletSpawnTicker;
			_enemy1BulletSpawner = enemy1BulletSpawner;
			eventBus.Subscribe<FrogPlayerDiedSignal>(OnFrogPlayerDied);
        }

		void Start()
		{
			GetComponent<Rigidbody2D>().velocity = _enemy1Settings.Velocity.Value;
			//InvokeRepeating(nameof(RepeatSpawn), 0, 2);
			//Debug.Log("Start called...");
			_enemy1BulletSpawner.Spawn(GetCurrentPosition());
		}

		void Update()
		{
			//Debug.Log("Enemy1 behaviour Update begin");
			_bulletSpawnTicker.Tick(GetCurrentPosition());
			//Debug.Log("Enemy1 behaviour Update end");
		}

		private Vector3 GetCurrentPosition()
		{
			return gameObject.transform.position;
		}

		public void OnFrogPlayerDied(FrogPlayerDiedSignal frogPlayerDiedSignal)
		{
			Debug.Log("Cancelling");
			//CancelInvoke(nameof(RepeatSpawn));
			_bulletSpawnTicker.Cancel();
		}

		public class Factory : PlaceholderFactory<Enemy1Behaviour>, IFactory<Enemy1Behaviour>
        {
        }
	}
}