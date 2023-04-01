using FrogSurvive.Events;
using UnityEngine;

namespace FrogSurvive.FrogPlayer
{
	public class SpriteHorizontalDirectionManager
	{
		public void OnFrogPlayerMoved(FrogPlayerMovedSignal frogPlayerMovedSignal)
		{
			if (DirectionChanged(frogPlayerMovedSignal.GameObject.transform.localScale.x, frogPlayerMovedSignal.Vector.x))
				frogPlayerMovedSignal.GameObject.transform.localScale =  new Vector3(-frogPlayerMovedSignal.GameObject.transform.localScale.x,
																					frogPlayerMovedSignal.GameObject.transform.localScale.y,
																					frogPlayerMovedSignal.GameObject.transform.localScale.z);
		}

		private bool DirectionChanged(float x1, float x2)
			=> x1 * x2 < 0;
	}
}
