using UnityEngine;

namespace Scripts
{
	public class KeyInput
	{
		public virtual float GetHorizontalAxis()
			=> Input.GetAxisRaw("Horizontal");

		public virtual float GetVertictalAxis()
			=> Input.GetAxisRaw("Vertical");
	}
}