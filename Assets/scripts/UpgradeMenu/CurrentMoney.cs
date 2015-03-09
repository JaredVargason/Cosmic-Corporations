using UnityEngine;
using System.Collections;

public class CurrentMoney : MonoBehaviour {

	public TextMesh _money;
	public int _playerNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        _money.text = "$" + BoardGameHandler._totalMoney[_playerNumber - 1].ToString("F2");
	}
}
