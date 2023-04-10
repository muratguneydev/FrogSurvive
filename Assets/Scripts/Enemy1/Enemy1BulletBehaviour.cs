using FrogSurvive.Events;
using UnityEngine;
using Zenject;

namespace FrogSurvive.Enemy1
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Enemy1BulletBehaviour : MonoBehaviour
	{
		private IEventBus _eventBus;
		private Enemy1BulletSettings _enemy1BulletSettings;

		[Inject]
        public void Construct(IEventBus eventBus, Enemy1BulletSettings enemy1BulletSettings)
        {
            _eventBus = eventBus;
			_enemy1BulletSettings = enemy1BulletSettings;
        }

		public class Factory : PlaceholderFactory<Enemy1BulletBehaviour>, IFactory<Enemy1BulletBehaviour>
        {
        }
	}
}