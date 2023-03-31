using UnityEngine;

namespace FrogSurvive.Events
{
	public class FrogPlayerMovedSignal
	{
		public FrogPlayerMovedSignal(GameObject gameObject, Vector2 vector)
		{
			GameObject = gameObject;
			Vector = vector;
		}

		public GameObject GameObject { get; }
		public Vector2 Vector { get; }
	}

	// public class FrogPlayerMovedRightSignal
	// {

	// }
}