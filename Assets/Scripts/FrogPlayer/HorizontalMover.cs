using Scripts;
using UnityEngine;

namespace FrogSurvive.FrogPlayer
{
	public class HorizontalMover
	{
		private KeyInput _keyInput;
		private readonly int _velocityMoveUnitsPerSecond;

		public HorizontalMover(KeyInput keyInput, int velocityMoveUnitsPerSecond)
		{
			_keyInput = keyInput;
			_velocityMoveUnitsPerSecond = velocityMoveUnitsPerSecond;
		}

		public virtual void Move(Rigidbody2D rigidBody)
		{
			var horizontalInput = _keyInput.GetHorizontalAxis();
			if (horizontalInput != 0)
				rigidBody.AddForce(new Vector2(horizontalInput * _velocityMoveUnitsPerSecond, 0));
		}
	}
}