using System;
using FrogSurvive.Events;
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
		private IEventBus _eventBus;


		[Inject]
		public virtual void Construct(IEventBus eventBus, FrogPlayerMover mover)
		{
			_mover = mover;
			_eventBus = eventBus;
		}

		void Start()
		{
			_rigidBody = GetComponent<Rigidbody2D>();
		}

		void Update()
		{
			_mover.Move(_rigidBody);
		}

		void OnCollisionEnter2D(Collision2D collision2D)
		{
			_eventBus.Fire(new FrogPlayerHitUISignal(collision2D.gameObject));
		}
	}
}
