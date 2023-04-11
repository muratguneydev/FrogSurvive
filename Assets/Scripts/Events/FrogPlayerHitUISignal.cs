using UnityEngine;

namespace FrogSurvive.Events
{
	public class FrogPlayerHitUISignal
	{
		public FrogPlayerHitUISignal(GameObject hittingObject)
		{
			HittingObject = hittingObject;
		}

		public GameObject HittingObject { get; }
	}
}