using Scripts;

public class InvokerSpy : IInvokable
{
	public bool IsInvoked { get; private set; }

	public void Invoke()
	{
		IsInvoked = true;
	}
}
