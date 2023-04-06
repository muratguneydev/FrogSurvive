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
			Debug.Log(GetComponent<Rigidbody2D>());
			Debug.Log(_enemy1Settings);
			GetComponent<Rigidbody2D>().velocity = _enemy1Settings.Velocity.Value;
		}

		public class Factory : PlaceholderFactory<Enemy1Behaviour>, IFactory<Enemy1Behaviour>
        {
        }
	}
}