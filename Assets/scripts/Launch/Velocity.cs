using UnityEngine;
using System.Collections;

public class Velocity : MonoBehaviour {

	public GameObject _rocket;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = _rocket.rigidbody.velocity.ToString();
	}
}
