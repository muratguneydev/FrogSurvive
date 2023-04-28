using System;
using UnityEngine;

namespace Scripts
{
	//To avoid dependency on the play mode and creating MonoBehavour objects, we use Zenject's interfaces. Tick() is the same as MonoBevour's Update and Initialize as Start.
	public class RealTimeTicker
	{
		private float _tickInterval = float.MaxValue;
		private Action _onTick = DefaultTickAction;
		private readonly DeltaTime _deltaTime;
		private float _currentElapsedSeconds;
		private bool _isEnabled;

		public RealTimeTicker(DeltaTime deltaTime) => _deltaTime = deltaTime;

		public void Set(float tickInterval) => _tickInterval = tickInterval;

		public void Set(Action onTick) => _onTick = onTick;

		public void Reset()//TODO:Add tests for this.
		{
			_isEnabled = true;
			_currentElapsedSeconds = 0;
		}

		public void Cancel() => _isEnabled = false;

		public void Tick()
		{
			if (!_isEnabled)
				return;

			UpdateCurrentElapsedSeconds(_deltaTime.GetSeconds());
			if (_currentElapsedSeconds < _tickInterval)
				return;

			_onTick();
			ResetCurrentElapsedSeconds();
		}

		//private bool IsTimerSet() => _tickInterval != default && _onTick != default;

		private void ResetCurrentElapsedSeconds() => _currentElapsedSeconds = 0;

		private void UpdateCurrentElapsedSeconds(float deltaTimeInSeconds) => _currentElapsedSeconds += deltaTimeInSeconds;
		private static Action DefaultTickAction = () => { Debug.Log("default tick action");};
	}
}