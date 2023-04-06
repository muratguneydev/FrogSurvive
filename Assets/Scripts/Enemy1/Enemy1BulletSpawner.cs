using Zenject;

namespace FrogSurvive.Enemy1
{
	public class Enemy1BulletSpawner
	{
		private readonly IFactory<Enemy1BulletBehaviour> _enemy1BulletFactory;
		private readonly Enemy1BulletSettings _enemy1BulletSettings;

		public Enemy1BulletSpawner(IFactory<Enemy1BulletBehaviour> enemy1BulletFactory, Enemy1BulletSettings enemy1BulletSettings)
		{
			_enemy1BulletFactory = enemy1BulletFactory;
			_enemy1BulletSettings = enemy1BulletSettings;
		}

		public virtual void Spawn()
		{
			var enemy1BulletBehaviour = _enemy1BulletFactory.Create();
			enemy1BulletBehaviour.transform.position = _enemy1BulletSettings.SpawnPosition;
		}
	}
}