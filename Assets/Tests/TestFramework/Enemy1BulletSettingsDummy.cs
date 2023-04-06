using FrogSurvive.Enemy1;
using UnityEngine;

public class Enemy1BulletSettingsDummy : Enemy1BulletSettings
{
	public Enemy1BulletSettingsDummy()
		: base(default, Vector3.zero, TestGameObject.GetNew())
	{
		
	}
}
