using UnityEngine;
using System.Collections;

public class RocketInfo : MonoBehaviour 
{
	public RoundHandler _timer;
	public float _money;
	public float _maxHeight;
	public float _flightTime;
    public float _startTime;
	public int _cardsCollected;
	public bool _marked = false;

	// Use this for initialization
	void Start () 
	{
		_money = 0f;
		_maxHeight = 1f;
		_flightTime = 0f;
		_cardsCollected = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.y > _maxHeight)
		{
			_maxHeight = transform.position.y;
		}
	}
    
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Terrain")
        {
            if (_timer._roundTimer > .1f && _marked == false)
            {
                _flightTime = _timer._roundTimer - _startTime;
                _marked = true;
            }
        }
    }
    
    void OnCollisionExit(Collision coll)
        {
            if (coll.collider.tag == "Terrain")
            {
                if (_timer._roundTimer > 0 && _marked == false)
                {
                    _startTime = _timer._roundTimer;
                }
            }
        }
}
