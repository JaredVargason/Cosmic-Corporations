using UnityEngine;
using System.Collections;

public class UpgradeEnder : MonoBehaviour {

	public DoneManager _doneButton1;
	public DoneManager _doneButton2;
	public DoneManager _doneButton3;
	public DoneManager _doneButton4;
	public SceneFade _fader;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_doneButton1._donezo == true) //&& _doneButton2._donezo == true
		    //&& _doneButton3._donezo == true && _doneButton4._donezo == true)

		{
			_fader.EndScene();
		}
	}
}
