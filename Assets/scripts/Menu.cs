using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{

	public static int _numberOfPlayers = 1;
	public static int _gameMode = 0;
	public int _selected = 0;
	public bool _action = false;
	public GameObject[] MenuItems = new GameObject[4];

	
	void Awake () 
	{

	}

	void Start () 
	{
		MenuItems [0] = GameObject.Find ("PLAY");
		MenuItems [0].renderer.material.color = Color.yellow;
		MenuItems [1] = GameObject.Find ("SETTINGS");
		MenuItems [2] = GameObject.Find ("EXTRAS");
		MenuItems [3] = GameObject.Find ("QUIT");
	}

	void Update () 
	{
		if (Input.GetAxis("MenuY") != 0 && _action == false)
		{
			MenuItems[_selected].renderer.material.color = Color.white;
			if (Input.GetAxis("MenuY") < 0)
			{
				_selected -= 1;
			}

			else
			{
				_selected += 1;
			}

			if (_selected > 3) 
			{
				_selected = 0;
			}

			else if (_selected < 0) 
			{
				_selected = 3;
			}

			MenuItems[_selected].renderer.material.color = Color.yellow;

			_action = true;
		}

		if (Input.GetAxis("MenuY") == 0)
		{
			_action = false;
		}

		if (Input.GetAxis("Thrust Ship 1") == 1) 
		{
			GameObject picked = MenuItems[_selected];
			switch (_selected) 
			{
				case 0:
				Application.LoadLevel(1); //need to scene fade
				break;

				case 1:
				break;

				case 2:
				break;

				case 3:
				Application.Quit();
				break;
			}
		}
	}

	void Select()
	{

	}
}
