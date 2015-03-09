using UnityEngine;
using System.Collections;

public class RoundHandler : MonoBehaviour {

	public SceneFade _fader;

	public RocketInfo _rocket1;
	public RocketInfo _rocket2;
	public RocketInfo _rocket3;
	public RocketInfo _rocket4;

	public ScoreUI _scoreUI1;
	public ScoreUI _scoreUI2;
	public ScoreUI _scoreUI3;
	public ScoreUI _scoreUI4;

	public float _roundTimer;



	// Use this for initialization
	void Start () {
		_roundTimer = -10;
		StartCoroutine (Controls ());
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (_roundTimer > 5)
		{
			if (_rocket1.rigidbody.velocity == new Vector3(0, 0, 0))			
			{
				_scoreUI1.gameObject.SetActive(true);
			}

			/*if (_rocket2 == null || _rocket2.rigidbody.velocity == new Vector3(0, 0, 0))			
			{
				_scoreUI2.enabled = true;
				_rocket2.enabled = false;
            }

			if (_rocket3 == null || _rocket3.rigidbody.velocity == new Vector3(0, 0, 0))			
			{
				_scoreUI3.enabled = true;
				_rocket3.enabled = false;
            }

			if (_rocket4 == null || _rocket4.rigidbody.velocity == new Vector3(0, 0, 0))			
			{
				_scoreUI4.enabled = true;
				_rocket4.enabled = false;
            }*/
		}

		if (_rocket1.transform.position.y > BoardGameHandler._topWorldBound ||
		    _rocket2.transform.position.y > BoardGameHandler._topWorldBound ||
		    _rocket3.transform.position.y > BoardGameHandler._topWorldBound ||
		    _rocket4.transform.position.y > BoardGameHandler._topWorldBound)
		{
			Application.LoadLevel(0);
		}


		_roundTimer += Time.deltaTime;
	}

	IEnumerator Controls()
	{
		yield return new WaitForSeconds (10);
            _rocket1.GetComponent<RocketBehavior>().enabled = true;
            _rocket2.GetComponent<RocketBehavior>().enabled = true;
            _rocket3.GetComponent<RocketBehavior>().enabled = true;
            _rocket4.GetComponent<RocketBehavior>().enabled = true;
    }
}