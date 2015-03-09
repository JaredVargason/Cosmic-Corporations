using UnityEngine;
using System.Collections;

public class SelectorBehavior : MonoBehaviour 
{

	public int _playerNumber;
	private int _speed = 8;
	private float _x, _y;
	
	void Start () //use root for player number, make a script for the root so u dont need to do it on all the buttons and then you can
		//make playernumber private
	{

	}

	void FixedUpdate () 
	{

		switch (_playerNumber)
		{
			case 1:
				_x = Input.GetAxis("Horizontal 1");
				_y = Input.GetAxis("Vertical 1");
				rigidbody.velocity = (new Vector3(_x, _y, 0f) * _speed);
				break;

			case 2:
				_x = Input.GetAxis("Horizontal 1");
				_y = Input.GetAxis("Vertical 1");
				rigidbody.AddForce(new Vector3(_x, _y, 0f) * _speed);
				break;


			case 3:
				_x = Input.GetAxis("Horizontal 1");
				_y = Input.GetAxis("Vertical 1");
				rigidbody.AddForce(new Vector3(_x, _y, 0f) * _speed);
				break;

			case 4:
				_x = Input.GetAxis("Horizontal 1");
				_y = Input.GetAxis("Vertical 1");
				rigidbody.AddForce(new Vector3(_x, _y, 0f) * _speed);
				break;
		}

		/*if (_x == 0 && _y == 0)
		{
			rigidbody.velocity = new Vector3(0, 0, 0);
		}*/
	}

	void OnCollision(Collision other)
	{

	}
}
