using Scripts;

public class DeltaTimeFake : DeltaTime
{
	public DeltaTimeFake(float nextDeltaToReturn)
	{
		NextDeltaToReturn = nextDeltaToReturn;
	}

	public float NextDeltaToReturn { get; set; }

	public override float GetSeconds()
	{
		return NextDeltaToReturn;
	}
}