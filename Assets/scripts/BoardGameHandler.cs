using UnityEngine;
using System.Collections;

public class BoardGameHandler : MonoBehaviour
{
	public static float _startingMoney = 30.0f;
	public static float _startingFuel = 5.0f;
	public static float _startingSpeed = 3.0f;

	//This script contains player information on upgrades, money, and cards owned.
	public static float _totalMoney1 = _startingMoney;
	public static float _totalMoney2 = _startingMoney;
	public static float _totalMoney3 = _startingMoney;
	public static float _totalMoney4 = _startingMoney;

	public static float _fuel1 = 120.0f;
	public static float _fuel2 = 120.0f;
	public static float _fuel3 = 5.0f;
	public static float _fuel4 = 5.0f;

	public static float _speed1 = 4.0f;
	public static float _speed2 = 4.0f;
	public static float _speed3 = 4.0f;
	public static float _speed4 = 3.0f;

	public static bool _hasMissle1 = true;
	public static bool _hasMissle2 = false;
	public static bool _hasMissle3 = false;
	public static bool _hasMissle4 = false;

	public static int _numberOfCards1 = 0;
	public static int _numberOfCards2 = 0;
	public static int _numberOfCards3 = 0;
	public static int _numberOfCards4 = 0;

	public static int _leftWorldBound = -500;
	public static int _rightWorldBound = 500;
	public static int _bottomWorldBound = 0;
	public static int _topWorldBound = 1500;
	public static int _checkpoint1 = 500;
	public static int _checkpoint2 = 1000;

	public static void ResetGame()
	{
		_totalMoney1 = _startingMoney;
		_totalMoney2 = _startingMoney;
		_totalMoney3 = _startingMoney;
		_totalMoney4 = _startingMoney;

		_fuel1 = _startingFuel;
		_fuel2 = _startingFuel;
		_fuel3 = _startingFuel;
		_fuel4 = _startingFuel;

		_speed1 = _startingSpeed;
		_speed2 = _startingSpeed;
		_speed3 = _startingSpeed;
		_speed4 = _startingSpeed;

		_hasMissle1 = false;
		_hasMissle2 = false;
		_hasMissle3 = false;
		_hasMissle4 = false;

		_numberOfCards1 = 0;
		_numberOfCards2 = 0;
		_numberOfCards3 = 0;
		_numberOfCards4 = 0;
	}
}
