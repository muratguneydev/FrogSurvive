using Scripts;

public class KeyInputStub : KeyInput
{
	private readonly float _result;

	public KeyInputStub(float result)
	{
		_result = result;
	}

	public override float GetHorizontalAxis()
	{
		return _result;
	}

	public override float GetVertictalAxis()
	{
		return _result;
	}
}
