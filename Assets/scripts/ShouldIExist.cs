using UnityEngine;
using System.Collections;

public class ShouldIExist : MonoBehaviour {

	public int _playerNumber;

	// Use this for initialization
	void Start () {
		if (_playerNumber > Menu._numberOfPlayers)
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
