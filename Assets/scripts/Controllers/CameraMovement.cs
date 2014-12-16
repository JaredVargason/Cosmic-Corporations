using UnityEngine;
using System.Collections;

//Sets camera position to start as a view of all four rockets and then zooms in to the specific one it follows.
//Position is then determined by rocket position.

public class CameraMovement : MonoBehaviour 
{

	public GameObject _player;
	private Vector3 _cameraPosition;
	private Vector3 _cameraStartPosition = new Vector3 (0.0f, 1.5f, -10.0f);
	private float _x, _y, _z;
	public float _time = -10.0f;

	//maybe try this using coroutines rather than a timer so it doesn't have to update

	void Start () 
	{
		transform.position = _cameraStartPosition;
		_cameraPosition = new Vector3 (_player.transform.position.x, _player.transform.position.y + 1, _player.transform.position.z - 5);
	}
	
	void Update () 
	{

		if (_time <= 0.0f && _time >= -6.0f) 
		{
			transform.position = Vector3.Lerp(transform.position, _cameraPosition, Time.deltaTime * 2);
		}

		else if (_time > 0.0f) 
		{
			_x = _player.transform.position.x;
			_y =_player.transform.position.y;
			_z = _player.transform.position.z;
			_cameraPosition = new Vector3(_x, _y + 1, _z - 5);
			transform.position = _cameraPosition;
		}

		_time += Time.deltaTime;
	}
}