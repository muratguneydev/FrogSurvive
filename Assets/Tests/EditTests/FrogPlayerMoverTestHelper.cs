using FrogSurvive.Events;
using FrogSurvive.FrogPlayer;
using Scripts;

public static class FrogPlayerMoverTestHelper
{
	public const int VelocityMoveUnitsPerSecond = 10;
	public static FrogPlayerMover GetMover(IEventBus eventBus, KeyInput keyInputStub)
		=> new FrogPlayerMover(eventBus, keyInputStub, VelocityMoveUnitsPerSecond);
	public static FrogPlayerMover GetMover(KeyInput keyInputStub)
		=> new FrogPlayerMover(new EventBusDummy(), keyInputStub, VelocityMoveUnitsPerSecond);
}
