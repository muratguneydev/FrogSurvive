using FrogSurvive.Enemy1;
using UnityEngine;

public class Enemy1SpawnerSpy : Enemy1Spawner
{
	public Enemy1SpawnerSpy()
		: base(new FactorySpy<Enemy1Behaviour>(), new Enemy1SettingsDummy())
	{
	}

	public override void Spawn()
	{
		IsSpawned = true;
	}

	public bool IsSpawned { get; private set; }
}

public class Enemy1SettingsDummy : Enemy1Settings
{
	public Enemy1SettingsDummy()
		: base(default, Vector3.zero, TestGameObject.GetNew())
	{
		
	}
}