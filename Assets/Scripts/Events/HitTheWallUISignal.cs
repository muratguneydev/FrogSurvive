using UnityEngine;

namespace FrogSurvive.Events
{
	public class HitTheWallUISignal
	{
		public HitTheWallUISignal(GameObject gameObject)
			: this(gameObject, false)
		{
			GameObject = gameObject;
		}

		public HitTheWallUISignal(GameObject gameObject, bool isDestroyable)
		{
			GameObject = gameObject;
			IsDestroyable = isDestroyable;
		}

		public GameObject GameObject { get; }
		public virtual bool IsDestroyable { get; }
	}
}