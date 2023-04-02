using UnityEngine;

namespace Scripts
{
	public class DeltaTime
	{
		public virtual float GetSeconds()
		{
			return Time.deltaTime;
		}
	}
}