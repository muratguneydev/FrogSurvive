using FrogSurvive.Enemy1;
using UnityEngine;

public class Enemy1BulletSpawnerSpy : Enemy1BulletSpawner
{
	public Enemy1BulletSpawnerSpy()
		: base(new FactorySpy<Enemy1BulletBehaviour>(), new Enemy1BulletSettingsDummy())
	{
	}

	public override void Spawn(Vector3 enemy1Position)
	{
		IsSpawned = true;
	}

	public bool IsSpawned { get; private set; }
}