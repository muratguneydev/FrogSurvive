using FrogSurvive.Events;
using Scripts;
using UnityEngine;

public class HitTheWallUISignalFactoryStub : HitTheWallUISignalFactory
{
	private readonly bool _isDestroyable;

	public HitTheWallUISignalFactoryStub(bool isDestroyable)
	{
		_isDestroyable = isDestroyable;
	}
	public override HitTheWallUISignal Get(GameObject gameObject)
		=> new HitTheWallUISignal(gameObject, _isDestroyable);
}