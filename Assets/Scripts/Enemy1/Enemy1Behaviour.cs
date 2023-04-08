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

		[Inject]
        public void Construct(IEventBus eventBus, Enemy1Settings enemy1Settings)
        {
            _eventBus = eventBus;
			_enemy1Settings = enemy1Settings;
        }

		void Start()
		{
			GetComponent<Rigidbody2D>().velocity = _enemy1Settings.Velocity.Value;
		}

		void FixedUpdate()
		{
			//We can change this to only fire if the current position is different than the previous position.
			//And this can be done in a Enemy1Mover class.
			//Not required now as we know that Enemy1 always moves.
			_eventBus.Fire(new Enemy1MovedSignal(gameObject));
		}

		public class Factory : PlaceholderFactory<Enemy1Behaviour>, IFactory<Enemy1Behaviour>
        {
        }
	}
}