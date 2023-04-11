using FrogSurvive.Events;
using UnityEngine;
using Zenject;

namespace FrogSurvive.Enemy1
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Enemy1Behaviour : MonoBehaviour
	{
		private IEventBus _eventBus;
		private Enemy1Settings _enemy1Settings;
		private Enemy1BulletSpawner _enemy1BulletSpawner;

		[Inject]
        public void Construct(IEventBus eventBus, Enemy1Settings enemy1Settings, Enemy1BulletSpawner enemy1BulletSpawner)
        {
            _eventBus = eventBus;
			_enemy1Settings = enemy1Settings;
			_enemy1BulletSpawner = enemy1BulletSpawner;
        }

		void Start()
		{
			GetComponent<Rigidbody2D>().velocity = _enemy1Settings.Velocity.Value;
			InvokeRepeating(nameof(RepeatSpawn), 0, 2);
		}

		// void FixedUpdate()
		// {
		// 	//We can change this to only fire if the current position is different than the previous position.
		// 	//And this can be done in a Enemy1Mover class.
		// 	//Not required now as we know that Enemy1 always moves.
			
		// 	//_eventBus.Fire(new Enemy1MovedSignal(gameObject));
		// }

		private void RepeatSpawn()
		{
			_enemy1BulletSpawner.Spawn(gameObject.transform.position);
		}

		public class Factory : PlaceholderFactory<Enemy1Behaviour>, IFactory<Enemy1Behaviour>
        {
        }
	}
}