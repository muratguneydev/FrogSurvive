using System;

namespace FrogSurvive.FrogPlayer
{
	[Serializable]
	public class FrogPlayerSettings
	{
		public FrogPlayerSettings(int horizontalVelocity)
		{
			HorizontalVelocity = horizontalVelocity;
		}

		public int HorizontalVelocity = 10;
	}
}