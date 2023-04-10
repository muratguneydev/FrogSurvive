using FrogSurvive.Events;
using UnityEngine;
using Zenject;

namespace Scripts
{
	public class WallHitBehaviour : MonoBehaviour
	{
		private IEventBus _eventBus;

		[Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

		void OnCollisionEnter2D(Collision2D collision)
		{
			//if (collision.gameObject.GetComponent<>())
			_eventBus.Fire(new HitTheWallUISignal(collision.gameObject));
		}
	}
}