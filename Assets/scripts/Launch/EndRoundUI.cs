using UnityEngine;
using System.Collections;

public class EndRoundUI : MonoBehaviour {

	public ScoreUI _UI1;
	public ScoreUI _UI2;
	public ScoreUI _UI3;
	public ScoreUI _UI4;
	public SceneFade _fader;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_UI1._donezo //&& _UI2._donezo && _UI3._donezo && _UI4._donezo)
		){
			_fader.EndScene();
		}
	}
}
