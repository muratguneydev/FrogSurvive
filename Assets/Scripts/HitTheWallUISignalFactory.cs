using FrogSurvive.Events;
using UnityEngine;

namespace Scripts
{
	public class HitTheWallUISignalFactory
	{
		public virtual HitTheWallUISignal Get(GameObject gameObject)
			=>  new HitTheWallUISignal(gameObject, gameObject.name == Constants.Enemy1BulletGameObjectName);
	}

}
