using FrogSurvive.Events;
using Scripts;
using UnityEngine;

namespace FrogSurvive.FrogPlayer
{
	public class FrogPlayerHealthManager
	{
		private IEventBus _eventBus;

		public FrogPlayerHealthManager(IEventBus eventBus)
		{
			_eventBus = eventBus;
		}

		public float RemainingHealth { get; private set; } = 100f;

		public void OnHitByAnObject(FrogPlayerHitUISignal frogPlayerHitUISignal)
		{
			if (frogPlayerHitUISignal.HittingObject.name == Constants.Enemy1BulletGameObjectName)
				RemainingHealth -= 20f;
			Debug.Log($"Remaining Health:{RemainingHealth}");

			if (RemainingHealth <= 0)
				_eventBus.Fire(new FrogPlayerDiedSignal());
		}
	}
}
