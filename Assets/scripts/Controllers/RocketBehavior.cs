using UnityEngine;
using System.Collections;

public class RocketBehavior : MonoBehaviour 
{

	public int _playerNumber;

	//public so it can be upgraded
	public float _speed;
	public bool _hasMissle;
	public float _fuel;

	private float _rotateSpeed = .5f; //speed of rotation
	
	void Start () 
	{
		_speed = BoardGameHandler._speed1;
		_fuel = BoardGameHandler._fuel1;
		_hasMissle = BoardGameHandler._hasMissle1;
		//random start location: 1 of 4.

		//possibly make wider usage destroyer script for number of players and if object should exist. ie. launchpad.
		//this script can serve as an example of what the script should do.

	}

	void FixedUpdate () 
	{
		Vector3 rotateZ = new Vector3(0, 0, 0);
		Vector3 thrust = new Vector3 (0, 0, 0);

		bool rotating = false;
		bool thrustersOn = false;
		bool shotMissle = false;

		switch (_playerNumber) 
		{
			case 1:

				if (Input.GetAxis ("Rotate Ship 1") != 0) 
				{
					rotateZ = Input.GetAxis ("Rotate Ship 1") * transform.forward * _rotateSpeed;
					rotating = true;
				}
				
				if (Input.GetAxis ("Thrust Ship 1") == 1) 
				{
					thrust = Input.GetAxis ("Thrust Ship 1") * transform.up * _speed;
					thrustersOn = true;
				}

				if (Input.GetAxis ("Missle Ship 1") == -1) 
				{
					shotMissle = true;
				}

				break;

			case 2:

				if (Input.GetAxis ("Rotate Ship 2") != 0) 
				{
					rotateZ = Input.GetAxis ("Rotate Ship 2") * transform.forward * _rotateSpeed;
					rotating = true;
				}

				if (Input.GetAxis ("Thrust Ship 2") == 1) 
				{
					thrust = Input.GetAxis ("Thrust Ship 2") * transform.up * _speed;
					thrustersOn = true;
				}
				
				if (Input.GetAxis ("Missle Ship 2") == -1) 
				{
					shotMissle = true;
				}

				break;

			case 3:
				if (Input.GetAxis ("Rotate Ship 3") != 0) 
				{
					rotateZ = Input.GetAxis ("Rotate Ship 3") * transform.forward * _rotateSpeed;
					rotating = true;
				}
				
				if (Input.GetAxis ("Thrust Ship 3") == 1) 
				{
					thrust = Input.GetAxis ("Thrust Ship 3") * transform.up * _speed;
					thrustersOn = true;
				}

				if (Input.GetAxis ("Missle Ship 3") == -1) 
				{
					shotMissle = true;
				}

				break;

			case 4:
				if (Input.GetAxis ("Rotate Ship 4") != 0) 
				{
					rotateZ = Input.GetAxis ("Rotate Ship 4") * transform.forward;
					rotating = true;
				}

				if (Input.GetAxis ("Thrust Ship 4") == 1) 
				{
					thrust = Input.GetAxis ("Thrust Ship 4") * transform.up * _speed;
					thrustersOn = true;
				}
				
				if (Input.GetAxis ("Missle Ship 4") == -1) 
				{
					shotMissle = true;
				}

				break;
		}

		//****************//
		//****CONTROLS****//
		//****************//

		/****** Rotation ******/

		if (rotating) 
		{
			rigidbody.AddTorque(rotateZ);

			if (rotating && transform.position.y < 1) 
			{ 

			}
		}
		/****** Acceleration ******/

		if (_fuel > 0 && thrustersOn)
		{
			rigidbody.AddForce(thrust);
			_fuel -= Time.deltaTime;
			transform.FindChild("FireParticle").particleSystem.enableEmission = true;

		}

		if (_fuel < 0 || thrustersOn == false) 
		{
			transform.FindChild("FireParticle").particleSystem.enableEmission = false;
		}

		/****** Missle ******/

		if (shotMissle && _hasMissle == true) 
		{
			GameObject prefab = Resources.Load("misslePrefab") as GameObject;
			GameObject missleInstance = Instantiate(prefab, transform.GetChild(0).position, transform.rotation) as GameObject;
			missleInstance.transform.parent = transform;
			gameObject.animation.Play();
			_hasMissle = false;
		}

		//***************//
		//***BEHAVIORS***//
		//***************//

		//****** World Bounds ******//

		if (transform.position.x < BoardGameHandler._leftWorldBound) 
		{
			rigidbody.AddForce (new Vector3 (20, 0, 0));
		}

		if (transform.position.x > BoardGameHandler._rightWorldBound) 
		{
			rigidbody.AddForce(new Vector3 (-20, 0, 0));
		}
	}
}