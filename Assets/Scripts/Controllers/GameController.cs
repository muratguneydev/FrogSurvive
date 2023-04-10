using System;
using FrogSurvive.Enemy1;
using FrogSurvive.Events;
using Scripts;
using UnityEngine;
using Zenject;

namespace FrogSurvive.Controllers
{
	public class GameController : IInitializable
	{
		private readonly Enemy1Spawner _enemy1Spawner;
		private readonly GameObjectDestroyer _gameObjectDestroyer;

		//private readonly Enemy1BulletSpawner _enemy1BulletSpawner;

		//private readonly IEventBus _eventBus;

		public GameController(Enemy1Spawner enemy1Spawner, GameObjectDestroyer gameObjectDestroyer)
		{
			_enemy1Spawner = enemy1Spawner;
			_gameObjectDestroyer = gameObjectDestroyer;
			//_enemy1BulletSpawner = enemy1BulletSpawner;
			// = eventBus;
		}

		public virtual void Initialize()
		{
			//Debug.Log("Spawned");
			_enemy1Spawner.Spawn();
			//_enemy1BulletSpawner.Spawn();

			
		}

		public void OnHitTheWall(HitTheWallUISignal hitTheWallUISignal)
		{
			_gameObjectDestroyer.Destroy(hitTheWallUISignal.GameObject);
		}

		//Note: We are not directly raising domain events from UIEventHandler or handling those events there. We are raising UI events instead and subscribe to those here.
		// public void OnResetButtonClicked(OnResetButtonClickedUISignal onResetButtonClickedUISignal)
		// {
		// 	//TODO: Do these in UIEventHandler as they are UI related?
		// 	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		// 	onResetButtonClickedUISignal.GameOverScreen.SetActive(false);
		// 	//
		// 	_eventBus.Fire(new GameResetSignal());
		// }

		// public void OnBirdHitThePipe(BirdHitThePipeUISignal birdHitThePipeSignal)
		// {
		// 	birdHitThePipeSignal.GameOverScreen.SetActive(true);
		// 	_eventBus.Fire(new GameOverSignal());
		// }
	}
}