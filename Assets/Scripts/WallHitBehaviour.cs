using FrogSurvive.Events;
using UnityEngine;
using Zenject;

namespace Scripts
{
	public class WallHitBehaviour : MonoBehaviour
	{
		private IEventBus _eventBus;
		private HitTheWallUISignalFactory _hitTheWallUISignalFactory;

		[Inject]
        public void Construct(IEventBus eventBus, HitTheWallUISignalFactory hitTheWallUISignalFactory)
        {
            _eventBus = eventBus;
			_hitTheWallUISignalFactory = hitTheWallUISignalFactory;
        }

		void OnCollisionEnter2D(Collision2D collision)
		{
			_eventBus.Fire(_hitTheWallUISignalFactory.Get(collision.gameObject));
		}
	}

}
