using UnityEngine;
using System.Collections;

public class DoneManager : MonoBehaviour {

	public int _playerNumber;
	public bool _pressed = false;
	public bool _donezo = false;
	public bool _triggered;

	void Update () 
	{
		_pressed = false;

		switch (_playerNumber)
		{ 
			case 1:
				if (Input.GetAxis("Thrust Ship 1") == 1 && _triggered == true)
				{
					_pressed = true;
				}
				break;
		}
			
		if (!_donezo && !_triggered)
		{
			renderer.material.color = Color.red;
		}
	
		else if (_triggered)
		{
			if (_pressed)
			{
				_donezo = true;
			}

			if (!_donezo)
			{
				renderer.material.color = Color.white;
			}

			else 
			{
				renderer.material.color = Color.green;
			}
		}
	}

	void OnTriggerEnter()
	{
		_triggered = true;
	}

	void OnTriggerExit()
	{
		if (_pressed != true)
		{
			_triggered = false;
		}
	}	
}
