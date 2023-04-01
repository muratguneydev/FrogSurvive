using UnityEngine;
using Zenject;

namespace FrogSurvive.FrogPlayer
{
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(Animator))]
	public class FrogPlayerBehaviour : MonoBehaviour
	{
		private FrogPlayerMover _mover;
		private Rigidbody2D _rigidBody;

		[Inject]
		public virtual void Construct(FrogPlayerMover mover)
		{
			_mover = mover;
		}

		void Start()
		{
			_rigidBody = GetComponent<Rigidbody2D>();
		}

		void Update()
		{
			_mover.Move(_rigidBody);
		}
	}
}
