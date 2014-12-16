using UnityEngine;
using System.Collections;

//Temporary script for pausing.

public class PauseMenu : MonoBehaviour {

	public bool _isPaused = false;
	public Camera _pauseCamera;
	public GameObject[] PauseItems = new GameObject[2];
	public int _selected = 0;
	public bool _action = false;
	
	void Start ()
	{
		PauseItems [0].renderer.material.color = Color.yellow;
	}

	//Pause game, stop players controls, etc.
	void Update ()
	{
		if (Input.GetButtonDown ("Start"))
		{
			_isPaused = !_isPaused;
			_selected = 0;
		}

		if (_isPaused)
		{
			Time.timeScale = 0;
			_pauseCamera.enabled = true;

			if (Input.GetAxis("MenuY") != 0 && !_action)
			{
				PauseItems[_selected].renderer.material.color = Color.white;

				if (Input.GetAxis("MenuY") < 0)
				{
					_selected--;
				}
				
				else 
				{
					_selected++;
				}

				if (_selected > 1 || _selected < 0)
				{
					_selected = 0;
				}

				PauseItems[_selected].renderer.material.color = Color.yellow;

				_action = true;
			}

			if (Input.GetAxis("MenuY") == 0)
			{
				_action = false;
			}
			
			if (Input.GetAxisRaw("Thrust Ship 1") == 1)
			{
				switch (_selected)
				{
					case 0:
						_isPaused = false;
						break;
						
					case 1:
						Time.timeScale = 1;
						BoardGameHandler.ResetGame();
						Application.LoadLevel(0);
						break;

					default:
						print("ur shit");
						break;
				}
			}

		}
		
		else
		{
			Time.timeScale = 1;
			_pauseCamera.enabled = false;
		}
	}
}
