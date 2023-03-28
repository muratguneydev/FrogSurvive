using Scripts;
using UnityEngine;
using Zenject;

namespace FrogSurvive.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class FrogPlayerBehaviour : MonoBehaviour
	{
		private KeyInput _keyInput;
		private Rigidbody2D _rigidBody;

		[Inject]
		public virtual void Construct(KeyInput keyInput)
		{
			_keyInput = keyInput;
		}

		// Start is called before the first frame update
		void Start()
		{
			_rigidBody = GetComponent<Rigidbody2D>();
		}

		// Update is called once per frame
		void Update()
		{
			var horizontalInput = _keyInput.GetHorizontalAxis();
			if (horizontalInput != 0)
				_rigidBody.AddForce(new Vector2(horizontalInput * 10, 0));
			Debug.Log(gameObject.transform.position.x);
		}
	}
}