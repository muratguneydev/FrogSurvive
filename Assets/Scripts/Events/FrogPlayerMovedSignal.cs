using UnityEngine;

namespace FrogSurvive.Events
{
	public class FrogPlayerMovedSignal
	{
		public FrogPlayerMovedSignal(GameObject frogPlayer, Vector2 vector)
		{
			FrogPlayer = frogPlayer;
			Vector = vector;
		}

		public GameObject FrogPlayer { get; }
		public Vector2 Vector { get; }
	}
}