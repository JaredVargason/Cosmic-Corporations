using UnityEngine;
using System.Collections;

public class IShouldntBeAlive : MonoBehaviour {

	public int _playerNumber;

	void Start () 
    {
		if (PlayMenu._numberOfPlayers < _playerNumber)
		{
			gameObject.SetActive(false);
		}
	}
}
