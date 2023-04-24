using FrogSurvive.Events;
using UnityEngine;
using Zenject;

namespace Scripts
{
	public class UIEventHandler : MonoBehaviour
	{
		private IEventBus _eventBus;
		//private KeyInput _keyInput;

		[Inject]
		public void Construct(IEventBus eventBus)
		{
			_eventBus = eventBus;
		}

		public void OnResetButtonClicked(GameObject gameOverScreen)
		{
			_eventBus.Fire(new ResetButtonClickedUISignal(gameOverScreen));
			Debug.Log("Game reset fired.");
		}
	}
}