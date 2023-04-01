using Scripts;
using UnityEngine;

public class KeyInputStub : KeyInput
{
	private readonly Vector2 _result;

	public KeyInputStub(Vector2 result)
	{
		_result = result.normalized;
	}

	public static KeyInput Right => new KeyInputStub(Vector2.right);
	public static KeyInput Left => new KeyInputStub(Vector2.left);
	public static KeyInput Up => new KeyInputStub(Vector2.up);
	public static KeyInput Down => new KeyInputStub(Vector2.down);
	public static KeyInput None => new KeyInputStub(Vector2.zero);

	public static KeyInput UpRight => new KeyInputStub(Vector2.up + Vector2.right);
	public static KeyInput DownRight => new KeyInputStub(Vector2.down + Vector2.right);
	public static KeyInput UpLeft => new KeyInputStub(Vector2.up + Vector2.left);
	public static KeyInput DownLeft => new KeyInputStub(Vector2.down + Vector2.left);

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
