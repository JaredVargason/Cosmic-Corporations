using UnityEngine;
using System.Collections;

public class MoneyMultiplier : MonoBehaviour 
{
	public RocketBehavior _rocket1;
	public RocketBehavior _rocket2;
	public RocketBehavior _rocket3;
	public RocketBehavior _rocket4;

	public float _money1;
	public float _money2;
	public float _money3;
	public float _money4;

	public float _maxHeight1;
	public float _maxHeight2;
	public float _maxHeight3;
	public float _maxHeight4;

	public float _flightTime1;
	public float _flightTime2;
	public float _flightTime3;
	public float _flightTime4;

	public int _cardsCollected1;
	public int _cardsCollected2;
	public int _cardsCollected3;
	public int _cardsCollected4;
	
	// Use this for initialization
	void Start () 
	{
		_money1 = 0;
		_money2 = 0;
		_money3 = 0;
		_money4 = 0;

		_maxHeight1 = 0;
		_maxHeight2 = 0;
		_maxHeight3 = 0;
		_maxHeight4 = 0;


	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
