using NUnit.Framework;
using Scripts;

public class RealTimeTickerTests
{
	[Test]
	public void ShouldInvokeOnTimeElapsed()
	{
		var invokerSpy = new InvokerSpy();
		var deltaTimer = new DeltaTimeFake(0.005f);
		
		var timer = new RealTimeTicker(0.02f, invokerSpy, deltaTimer);
		timer.Tick();
		Assert.IsFalse(invokerSpy.IsInvoked);

		deltaTimer.NextDeltaToReturn = 0.01f;
		timer.Tick();
		Assert.IsFalse(invokerSpy.IsInvoked);

		deltaTimer.NextDeltaToReturn = 0.01f;
		timer.Tick();
		Assert.IsTrue(invokerSpy.IsInvoked);
	}
}
