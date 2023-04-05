using UnityEngine;
using Zenject;

public class FactorySpy<TBehaviour> : IFactory<TBehaviour>
										where TBehaviour : Component
{
	public TBehaviour Create()
	{
		IsCreateInvoked = true;
		CreatedObject = TestGameObject.GetNew().AddComponent<TBehaviour>();
		return CreatedObject;
	}

	public bool IsCreateInvoked { get; private set; }
	public TBehaviour CreatedObject { get; private set; }
}