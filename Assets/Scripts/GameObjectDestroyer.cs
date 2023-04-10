using UnityEngine;

namespace Scripts
{
	public class GameObjectDestroyer
	{
		public virtual void Destroy(GameObject gameObject)
		{
			GameObject.Destroy(gameObject);
		}
	}
}