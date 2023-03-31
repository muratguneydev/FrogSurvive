// using FrogSurvive.Events;
// using UnityEngine;
// using Zenject;

// namespace Scripts
// {
// 	public class UIEventHandler : MonoBehaviour
// {
// 	private IEventBus _eventBus;
// 	private KeyInput _keyInput;

// 	[Inject]
// 	public void Construct(IEventBus eventBus, KeyInput keyInput)
// 	{
// 		_eventBus = eventBus;
// 		_keyInput = keyInput;
// 	}

// 	// public void OnMoveKeyPressed()
// 	// {
// 	// 	_eventBus.Fire(new MoveKeyPressedUISignal(_keyInput.GetNormalizedVector()));
// 	// 	Debug.Log("Move event fired.");
// 	// }
// }
// }