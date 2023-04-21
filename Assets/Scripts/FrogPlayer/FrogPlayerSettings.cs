using System;
using UnityEngine;

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
		public GameObject FrogPlayer => GameObject.FindGameObjectWithTag("Player");//Note: Cannot drag/drop assign in Unity as this is not a prefab.
	}
}