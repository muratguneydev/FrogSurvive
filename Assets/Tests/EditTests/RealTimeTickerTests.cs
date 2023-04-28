using NUnit.Framework;
using Scripts;

public class RealTimeTickerTests
{
	private bool _isInvoked;

	[Test]
	public void ShouldInvokeOnTimeElapsed()
	{
		var deltaTime = new DeltaTimeFake(0.005f);
		
		var timer = new RealTimeTicker(deltaTime);

		timer.Set(0.02f);
		timer.Set(OnTick);
		_isInvoked = false;
		timer.Reset();

		timer.Tick();
		Assert.IsFalse(_isInvoked);

		deltaTime.NextDeltaToReturn = 0.01f;
		timer.Tick();
		Assert.IsFalse(_isInvoked);

		deltaTime.NextDeltaToReturn = 0.01f;
		timer.Tick();
		Assert.IsTrue(_isInvoked);
	}

	[Test]
	public void ShouldNotInvokeWhenCancelled()
	{
		var deltaTime = new DeltaTimeFake(0.01f);
		var timer = new RealTimeTicker(deltaTime);

		timer.Set(0.02f);
		timer.Set(OnTick);
		_isInvoked = false;
		timer.Reset();
		
		timer.Tick();
		Assert.IsFalse(_isInvoked);

		deltaTime.NextDeltaToReturn = 0.01f;
		timer.Tick();
		Assert.IsTrue(_isInvoked);

		deltaTime.NextDeltaToReturn = 1f;
		_isInvoked = false;
		timer.Cancel();
		timer.Tick();
		Assert.IsFalse(_isInvoked);
	}

	[Test]
	public void ShouldStartInvokeWhenResetAfterCancel()
	{
		var deltaTime = new DeltaTimeFake(0.01f);
		var timer = new RealTimeTicker(deltaTime);

		timer.Set(0.02f);
		timer.Set(OnTick);
		timer.Cancel();
		_isInvoked = false;
		timer.Reset();
		
		timer.Tick();
		Assert.IsFalse(_isInvoked);

		deltaTime.NextDeltaToReturn = 0.01f;
		timer.Tick();
		Assert.IsTrue(_isInvoked);
	}


	private void OnTick()
	{
		_isInvoked = true;
	}
}
