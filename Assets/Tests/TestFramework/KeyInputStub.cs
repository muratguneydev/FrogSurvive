using Scripts;
using UnityEngine;

public class KeyInputStub : KeyInput
{
	private readonly Vector2 _result;

	public KeyInputStub(Vector2 result)
	{
		_result = result;
	}

	// public override float GetHorizontalAxis()
	// {
	// 	return _result;
	// }

	// public override float GetVertictalAxis()
	// {
	// 	return _result;
	// }

	public override Vector2 GetNormalizedVector()
	{
		return _result;
	}
}

public class RightHorizontalInputStub : KeyInputStub
{
	public RightHorizontalInputStub()
		: base(new Vector2(1, 0))
	{
		
	}
}

public class LeftHorizontalInputStub : KeyInputStub
{
	public LeftHorizontalInputStub()
		: base(new Vector2(-1, 0))
	{
		
	}
}

public class NoMoveInputStub : KeyInputStub
{
	public NoMoveInputStub()
		: base(Vector2.zero)
	{
		
	}
}
