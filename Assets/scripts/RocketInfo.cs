using UnityEngine;
using System.Collections;

public class RocketInfo : MonoBehaviour 
{
	public float _money;
	public float _maxHeight;
	public float _flightTime;
	public int _cardsCollected;

	// Use this for initialization
	void Start () 
	{
		_money = 0f;
		_maxHeight = 0f;
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
}
