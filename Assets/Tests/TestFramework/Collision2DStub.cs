using System.Reflection;
using UnityEngine;

public class Collision2DStub : Collision2D
{
	public Collision2DStub(GameObject incomingGameObject)
	{
		var collision2DType = typeof(Collision2D);
		var rigidbody2D = incomingGameObject.AddComponent<Rigidbody2D>();
		var fieldInfo = collision2DType.GetField("m_Rigidbody", BindingFlags.Instance | BindingFlags.NonPublic);
        fieldInfo.SetValue(this, rigidbody2D.GetInstanceID());
	}

	public Collision2DStub()
		: this(TestGameObject.GetNew())
	{
		
	}
}