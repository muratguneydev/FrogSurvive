using NUnit.Framework;
using Scripts;
using UnityEngine;

public class VelocityTests
{
	[Test]
	public void Should_GetVelocityAsNormalizedVectorTimesSpeed()
	{
		var speed = 2f;
		var direction = new Vector2(4, 4);
		//Act
		var velocity = new Velocity(speed, direction);
		//Assert
		Assert.AreEqual(direction.normalized * speed, velocity.Value);
	}
}
