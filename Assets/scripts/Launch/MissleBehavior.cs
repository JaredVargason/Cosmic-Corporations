using UnityEngine;
using System.Collections;

public class MissleBehavior : MonoBehaviour 
{
	//script needs to have a collision box for missle and use ignore collision on the parent

	private float _missleSpeed = 10;
	private bool _shot = false;

	void Awake()
	{

	}

	void Start() 
	{
		StartCoroutine (Shoot ());

	}

	void FixedUpdate () 
	{
		if (_shot == false) 
		{
			transform.position = Vector3.MoveTowards(transform.position, transform.parent.FindChild("MissleTarget1").transform.position, .0029f);
		}

		if (_shot == true) 
		{
			rigidbody.AddForce (transform.up * _missleSpeed);
		}

	}

	IEnumerator Shoot () 
	{
		yield return new WaitForSeconds (5f);
		rigidbody.isKinematic = false;
		rigidbody.velocity = transform.parent.rigidbody.velocity;
		transform.parent = null;
		_shot = true;
		yield return new WaitForSeconds (10.0f);
		Destroy (gameObject);
	}





	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.rigidbody.AddForce(rigidbody.velocity.normalized * 10, ForceMode.Impulse);
		}

		else if (collision.gameObject.tag == "Terrain")
		{

		}

		Destroy (gameObject);
	}
}
