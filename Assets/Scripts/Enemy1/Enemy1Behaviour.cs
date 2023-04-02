using FrogSurvive.Events;
using UnityEngine;
using Zenject;

namespace FrogSurvive.Enemy1
{
	public class Enemy1Behaviour : MonoBehaviour
	{
		//[SerializeField] private float moveSpeed;
		//private LeftMover _leftMover;
		private IEventBus _eventBus;

		[Inject]
        public void Construct(IEventBus eventBus)//, LeftMover leftMover)
        {
            _eventBus = eventBus;
			//_leftMover = leftMover;
        }

		// void Update()
		// {
		// 	MoveLeft();
		// }

		// private void MoveLeft()
		// {
		// 	transform.position = _leftMover.Move(transform.position, Time.deltaTime);
		// 	_eventBus.Fire(new ObjectMovedSignal(gameObject));
		// }

		public class Factory : PlaceholderFactory<Enemy1Behaviour>, IFactory<Enemy1Behaviour>
        {
        }
	}
}