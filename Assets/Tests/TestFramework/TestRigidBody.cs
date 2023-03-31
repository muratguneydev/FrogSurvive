using UnityEngine;

public static class TestRigidBody
{
	public static Rigidbody2D GetNew()
	{
		var gameObject = new GameObject();
		var rigidBody = gameObject.AddComponent<Rigidbody2D>();
		return rigidBody;
	}

	public static float GetX(this Rigidbody2D rigidBody)
		=> rigidBody.gameObject.transform.position.x;
}
