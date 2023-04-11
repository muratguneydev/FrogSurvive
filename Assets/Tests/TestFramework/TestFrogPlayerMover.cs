using FrogSurvive.Events;
using FrogSurvive.FrogPlayer;
using Scripts;

public static class TestFrogPlayerMover
{
	public const int VelocityMoveUnitsPerSecond = 10;
	public static FrogPlayerMover GetNew(IEventBus eventBus, KeyInput keyInputStub)
		=> new FrogPlayerMover(eventBus, keyInputStub, VelocityMoveUnitsPerSecond);
	public static FrogPlayerMover GetNew(KeyInput keyInputStub)
		=> GetNew(new EventBusDummy(), keyInputStub);

	public static FrogPlayerMover GetNew()
		=> GetNew(KeyInputStub.None);
}