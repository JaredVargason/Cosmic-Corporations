using UnityEngine;
using System.Collections;

public class RoundHandler : MonoBehaviour {

	public SceneFade _fader;
	public RocketBehavior _rocket1;
	public RocketBehavior _rocket2;
	public RocketBehavior _rocket3;
	public RocketBehavior _rocket4;
	public bool _roundOver = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (_rocket1._fuel <= 0 && _rocket1.transform.position.y < 1
		    )
		{
			_fader.EndScene();
		}
	}
}