using FrogSurvive.Events;
using Scripts;
using UnityEngine;

namespace FrogSurvive.FrogPlayer
{
	public class FrogPlayerHealthManager
	{
		private IEventBus _eventBus;
		private readonly FrogPlayerSettings _frogPlayerSettings;

		public FrogPlayerHealthManager(IEventBus eventBus, FrogPlayerSettings frogPlayerSettings)
		{
			_eventBus = eventBus;
			_frogPlayerSettings = frogPlayerSettings;
		}

		public float RemainingHealth { get; private set; } = 100f;

		public void OnHitByAnObject(FrogPlayerHitUISignal frogPlayerHitUISignal)
		{
			if (frogPlayerHitUISignal.HittingObject.name == Constants.Enemy1BulletGameObjectName)
				RemainingHealth -= 20f;
			Debug.Log($"Remaining Health:{RemainingHealth}");

			if (RemainingHealth <= 0)
				_eventBus.Fire(new FrogPlayerDiedSignal(_frogPlayerSettings.FrogPlayer));
		}
	}
}
