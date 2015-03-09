using UnityEngine;
using System.Collections;

public class FlightHUD : MonoBehaviour {
    
    public RoundHandler _timer;
    public RocketInfo _rocket;
    public TextMesh _altitude;
    public TextMesh _time;
    
	// Use this for initialization
	void Start () {
	    StartCoroutine("EnableUI");
	}
	
	// Update is called once per frame
	void Update () {
	    _time.text = _timer._roundTimer.ToString("F2") + "sec";
        _altitude.text = _rocket.transform.position.y.ToString("F2") + "m";
	}
    
    IEnumerator EnableUI()
    {
        yield return new WaitForSeconds(10f);
        foreach (Transform child in transform)
        {
            child.renderer.enabled = true;
        }
    }
}
