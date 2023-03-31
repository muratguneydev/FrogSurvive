using FrogSurvive.Events;
using Scripts;
using UnityEngine;

namespace FrogSurvive.FrogPlayer
{
	public class HorizontalMover
	{
		private readonly IEventBus _eventBus;
		private KeyInput _keyInput;
		private readonly int _velocityMoveUnitsPerSecond;

		public HorizontalMover(IEventBus eventBus, KeyInput keyInput, int velocityMoveUnitsPerSecond)
		{
			_eventBus = eventBus;
			_keyInput = keyInput;
			_velocityMoveUnitsPerSecond = velocityMoveUnitsPerSecond;
		}

		public virtual void Move(Rigidbody2D rigidBody)
		{
			var direction = _keyInput.GetNormalizedVector();
			if (direction == Vector2.zero)
			 	return;

			rigidBody.velocity =  direction * _velocityMoveUnitsPerSecond;
			_eventBus.Fire(new FrogPlayerMovedSignal(rigidBody.gameObject, direction));
			//Debug.Log(direction);
			// var horizontalInput = _keyInput.GetHorizontalAxis();
			// if (horizontalInput != 0)
			// 	rigidBody.velocity = Vector2.right * _velocityMoveUnitsPerSecond;
			//	//rigidBody.AddForce(new Vector2(horizontalInput * _velocityMoveUnitsPerSecond, 0));
		}
	}
}