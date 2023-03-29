using UnityEngine;
using Zenject;

namespace FrogSurvive.FrogPlayer
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class FrogPlayerBehaviour : MonoBehaviour
	{
		private HorizontalMover _horizontalMover;
		private Rigidbody2D _rigidBody;

		[Inject]
		public virtual void Construct(HorizontalMover horizontalMover)
		{
			_horizontalMover = horizontalMover;
		}

		void Start()
		{
			_rigidBody = GetComponent<Rigidbody2D>();
		}

		void Update()
		{
			_horizontalMover.Move(_rigidBody);
		}
	}
}
