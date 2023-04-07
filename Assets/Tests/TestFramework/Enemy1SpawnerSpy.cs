using FrogSurvive.Enemy1;

public class Enemy1SpawnerSpy : Enemy1Spawner
{
	public Enemy1SpawnerSpy()
		: base(new FactorySpy<Enemy1Behaviour>(), new Enemy1SettingsDummy(), new EventBusSpy())
	{
	}

	public override void Spawn()
	{
		IsSpawned = true;
	}

	public bool IsSpawned { get; private set; }
}
