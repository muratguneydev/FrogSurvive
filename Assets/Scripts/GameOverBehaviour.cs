using FrogSurvive.Events;
using UnityEngine;
using Zenject;

namespace Scripts
{
	public class GameOverBehaviour : MonoBehaviour
	{
		[Inject]
		public void Construct(IEventBus eventBus)
		{
			//Note:We cannot subscribe for a MonoBehaviour method from the installers like normal classes.
			//Zenject gives circular dependency error for some reason.
			//That's why we need to subscribe this way.
			eventBus.Subscribe<FrogPlayerDiedSignal>(OnFrogPlayerDied);
		}
		private void OnFrogPlayerDied(FrogPlayerDiedSignal frogPlayerDiedSignal)
		{
			gameObject.SetActive(true);
		}
	}
}

