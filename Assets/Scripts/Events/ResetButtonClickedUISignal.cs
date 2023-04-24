using UnityEngine;

namespace FrogSurvive.Events
{
	public class ResetButtonClickedUISignal
	{
		public ResetButtonClickedUISignal(GameObject gameOverScreen)
		{
			GameOverScreen = gameOverScreen;
		}

		public GameObject GameOverScreen { get; }
	}
}