using UnityEngine;
using Zenject;

namespace Scripts
{
	//To avoid dependency on the play mode and creating MonoBehavour objects, we use Zenject's interfaces. Tick() is the same as MonoBevour's Update and Initialize as Start.
	public class RealTimeTicker : ITickable
	{
		private readonly float _requiredElapsedSecondsForTrigger;
		private readonly IInvokable _invokable;
		private readonly DeltaTime _deltaTime;
		private float _currentElapsedSeconds;

		public RealTimeTicker(float requiredElapsedSecondsForTrigger, IInvokable invokable, DeltaTime deltaTime)
		{
			Debug.Log($"RealTimeTicker constructed with invokable of {invokable}");
			_requiredElapsedSecondsForTrigger = requiredElapsedSecondsForTrigger;
			_invokable = invokable;
			_deltaTime = deltaTime;
		}

		public void Tick()
		{
			UpdateCurrentElapsedSeconds(_deltaTime.GetSeconds());
			if (_currentElapsedSeconds < _requiredElapsedSecondsForTrigger)
				return;
			
			_invokable.Invoke();
			ResetCurrentElapsedSeconds();
		}

		private void ResetCurrentElapsedSeconds()
		{
			_currentElapsedSeconds = 0;
		}

		private void UpdateCurrentElapsedSeconds(float deltaTimeInSeconds)
		{
			_currentElapsedSeconds += deltaTimeInSeconds;
		}
	}
}