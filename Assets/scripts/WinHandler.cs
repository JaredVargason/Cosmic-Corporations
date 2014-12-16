using UnityEngine;
using System.Collections;

public class WinHandler : MonoBehaviour {

	public GameObject _rocket1;
	public GameObject _rocket2;
	public GameObject _rocket3;
	public GameObject _rocket4;
	
	void Start () {

	}

	void Update () {
		if (_rocket1.transform.position.y > BoardGameHandler._topWorldBound ||
		    _rocket2.transform.position.y > BoardGameHandler._topWorldBound ||
		    _rocket3.transform.position.y > BoardGameHandler._topWorldBound ||
		    _rocket4.transform.position.y > BoardGameHandler._topWorldBound)
		{
			Application.LoadLevel(0);
		}


	}
}
