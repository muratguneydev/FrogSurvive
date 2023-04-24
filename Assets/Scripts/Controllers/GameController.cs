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
		private readonly SceneManagerWrapper _sceneManagerWrapper;
		private readonly IEventBus _eventBus;

		public GameController(Enemy1Spawner enemy1Spawner, GameObjectDestroyer gameObjectDestroyer, SceneManagerWrapper sceneManagerWrapper,
			IEventBus eventBus)
		{
			_enemy1Spawner = enemy1Spawner;
			_gameObjectDestroyer = gameObjectDestroyer;
			_sceneManagerWrapper = sceneManagerWrapper;
			_eventBus = eventBus;
		}

		public virtual void Initialize()
		{
			_enemy1Spawner.Spawn();
		}

		public void OnGameReset(ResetButtonClickedUISignal resetButtonClickedUISignal)
		{
			_sceneManagerWrapper.LoadScene("MainScene");
			resetButtonClickedUISignal.GameOverScreen.SetActive(false);
			_eventBus.Fire(new GameResetSignal());
		}

		public void OnHitTheWall(HitTheWallUISignal hitTheWallUISignal)
		{
			if (hitTheWallUISignal.IsDestroyable)
				_gameObjectDestroyer.Destroy(hitTheWallUISignal.GameObject);
		}
	}
}