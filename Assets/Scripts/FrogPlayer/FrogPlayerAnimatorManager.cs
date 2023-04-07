using FrogSurvive.Events;
using UnityEngine;

public class FrogPlayerAnimatorManager
{
	public void OnFrogPlayerMoved(FrogPlayerMovedSignal frogPlayerMovedSignal)
	{
		var animator = frogPlayerMovedSignal.FrogPlayer.GetComponent<Animator>();
		animator.SetBool("isPlayerMovingVertically", frogPlayerMovedSignal.Vector.y != 0);
		animator.SetBool("isPlayerMovingHorizontally", frogPlayerMovedSignal.Vector.x != 0);
	}
}