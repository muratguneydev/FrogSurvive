using UnityEngine;

namespace Scripts
{
	public class KeyInput
	{
		// public virtual float GetHorizontalAxis()
		// 	=> Input.GetAxisRaw("Horizontal");

		// public virtual float GetVertictalAxis()
		// 	=> Input.GetAxisRaw("Vertical");

		public virtual Vector2 GetNormalizedVector()
			=> new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
	}
}