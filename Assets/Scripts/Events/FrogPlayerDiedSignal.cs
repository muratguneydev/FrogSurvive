using UnityEngine;

namespace FrogSurvive.Events
{
	public class FrogPlayerDiedSignal
	{
		public FrogPlayerDiedSignal(GameObject frogPlayer)
		{
			FrogPlayer = frogPlayer;
		}

		public GameObject FrogPlayer { get; }
	}
}