using FrogSurvive.Enemy1;
using FrogSurvive.Events;
using Scripts;
using Zenject;

namespace FrogSurvive.Controllers
{
	public class GameController : IInitializable
	{
		private readonly Enemy1Spawner _enemy1Spawner;
		private readonly GameObjectDestroyer _gameObjectDestroyer;

		public GameController(Enemy1Spawner enemy1Spawner, GameObjectDestroyer gameObjectDestroyer)
		{
			_enemy1Spawner = enemy1Spawner;
			_gameObjectDestroyer = gameObjectDestroyer;
		}

		public virtual void Initialize()
		{
			_enemy1Spawner.Spawn();
		}

		public void OnHitTheWall(HitTheWallUISignal hitTheWallUISignal)
		{
			if (hitTheWallUISignal.IsDestroyable)
				_gameObjectDestroyer.Destroy(hitTheWallUISignal.GameObject);
		}
	}
}