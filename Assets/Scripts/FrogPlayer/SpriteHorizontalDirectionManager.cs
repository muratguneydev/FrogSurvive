using FrogSurvive.Events;
using UnityEngine;

namespace FrogSurvive.FrogPlayer
{
	public class SpriteHorizontalDirectionManager
	{
		public void OnFrogPlayerMoved(FrogPlayerMovedSignal frogPlayerMovedSignal)
		{
			if (DirectionChanged(frogPlayerMovedSignal.FrogPlayer.transform.localScale.x, frogPlayerMovedSignal.Vector.x))
				frogPlayerMovedSignal.FrogPlayer.transform.localScale =  new Vector3(-frogPlayerMovedSignal.FrogPlayer.transform.localScale.x,
																					frogPlayerMovedSignal.FrogPlayer.transform.localScale.y,
																					frogPlayerMovedSignal.FrogPlayer.transform.localScale.z);
		}

		private bool DirectionChanged(float currentScaleX, float normalizedDirectionX)
			=> currentScaleX * normalizedDirectionX < 0;
	}
}
