using Zenject;

namespace FrogSurvive.Enemy1
{
	public class Enemy1Spawner
	{
		private readonly IFactory<Enemy1Behaviour> _enemy1Factory;
		private readonly Enemy1Settings _enemy1Settings;

		public Enemy1Spawner(IFactory<Enemy1Behaviour> enemy1Factory, Enemy1Settings enemy1Settings)
		{
			_enemy1Factory = enemy1Factory;
			_enemy1Settings = enemy1Settings;
		}

		public virtual void Spawn()
		{
			var enemy1Behaviour = _enemy1Factory.Create();
			enemy1Behaviour.transform.position = _enemy1Settings.SpawnPosition;
		}
	}
}