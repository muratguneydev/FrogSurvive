using UnityEngine;

namespace FrogSurvive.Events
{
	public class HitTheWallUISignal
	{
		public HitTheWallUISignal(GameObject gameObject)
		{
			GameObject = gameObject;
		}

		public GameObject GameObject { get; }
	}
}