using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardGameHandler : MonoBehaviour
{
    public static int[] _rocketType = new int[4];

	public static float _startingMoney = 30.0f;
	public static float _startingFuel = 5.0f;
	public static float _startingSpeed = 6.0f;
	public static float _startingDrag = .6f;
	public static float _startingAngularDrag = 1.5f;

	//This script contains player information on upgrades, money, and cards owned.
	public static float[] _totalMoney = new float[4] {30f, 30f, 30f, 30f};
    public static float[] _fuel = new float[4] {120f, 5f, 5f, 5f};
    public static float[]_speed = new float[4] {12f, 6f, 6f, 6f};
    public static float[] _drag = new float[4] {0.6f, 0.6f, 0.6f, 0.6f};
    public static float[] _angularDrag = new float[4] {1.5f, 1.5f, 1.5f, 1.5f};
	public static bool[] _hasMissle = new bool[4] {true, false, false, false};
    public static bool[] _hasMagnet = new bool[4] {true, false, false, false};
    public static int[] _numberOfCards = new int[4] {0, 0, 0, 0};

	public static int _leftWorldBound = -500;
	public static int _rightWorldBound = 500;
	public static int _bottomWorldBound = 0;
	public static int _topWorldBound = 1500;
	public static int _checkpoint1 = 500;
	public static int _checkpoint2 = 1000;
    
    public static List<int>[] cards = new List<int>[4];
    
    void Start()
    {
        _totalMoney[0] = 30f;
        _totalMoney[1] = 30f;
        _totalMoney[2] = 30f;
        _totalMoney[3] = 30f;
        
        _fuel[0] = 30f;
        _fuel[1] = 30f;
        _fuel[2] = 30f;
        _fuel[3] = 30f;
        
        _speed[0] = 20f;
        _drag[0] = 0.6f;
        _angularDrag[0] = 0.5f;
    }
    
	public static void ResetGame()
	{
		for (int i = 0; i <= 3; i++)
        {
            _totalMoney[i] = 30.0f;
            _fuel[i] = 5.0f;
            _speed[i] = 6.0f;
            _drag[i] = 0.6f;
            _angularDrag[i] = 1.5f;
            
            _hasMissle[i] = false;
            _hasMagnet[i] = false;
            
            _numberOfCards[i] = 0;
            
            
            cards[i] = new List<int>();
        }
	}
}
