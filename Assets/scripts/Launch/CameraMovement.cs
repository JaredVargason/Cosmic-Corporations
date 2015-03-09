using UnityEngine;
using System.Collections;

//Sets camera position to start as a view of all four rockets and then zooms in to the specific one it follows.
//Position is then determined by rocket position.

public class CameraMovement : MonoBehaviour 
{
    public int _playerNumber;
	public GameObject _player;
	private Vector3 _cameraStartPosition = new Vector3 (0.0f, 1.5f, -15.0f);
	private bool _ended = false;

	void Start () 
	{
        /*foreach(GameObject rocket in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (rocket.GetComponent<RocketBehavior>()._playerNumber == _playerNumber)
            {
                _player = rocket;
            }
        }*/
		StartCoroutine (CameraFocus(6f));
	}
	
	void LateUpdate () 
	{
		if (_ended) 
		{
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 2, _player.transform.position.z - 10);
		}
	}

	IEnumerator CameraFocus(float time)
	{
		float elapsedTime = 0;
		transform.position = _cameraStartPosition;
		yield return new WaitForSeconds (4);
		while (elapsedTime < time)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y + 2, _player.transform.position.z - 10), Time.deltaTime * 2);
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		_ended = true;
	}
}