using UnityEngine;

namespace FrogSurvive.Events
{
	public class Enemy1MovedSignal
	{
		public Enemy1MovedSignal(GameObject enemy1)
		{
			Enemy1 = enemy1;
		}

		public GameObject Enemy1 { get; }
	}
}