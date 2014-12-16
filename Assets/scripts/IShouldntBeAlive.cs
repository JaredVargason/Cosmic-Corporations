using UnityEngine;
using System.Collections;

public class IShouldntBeAlive : MonoBehaviour {

	public int _playerNumber;

	// Use this for initialization
	void Start () {
		if (Menu._numberOfPlayers < _playerNumber)
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
