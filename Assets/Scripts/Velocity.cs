using System;
using UnityEngine;

namespace Scripts
{
	[Serializable]
	public struct Velocity
	{
		
		public Velocity(float speedInUnitsPerSecond, Vector2 direction)
		{
			SpeedInUnitsPerSecond = speedInUnitsPerSecond;
			Direction = direction;
		}

		public float SpeedInUnitsPerSecond;
		public Vector2 Direction;

		public Vector2 Value => Direction.normalized * SpeedInUnitsPerSecond;
	}
}