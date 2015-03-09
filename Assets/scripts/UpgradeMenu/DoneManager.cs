using UnityEngine;
using System.Collections;

public class DoneManager : MonoBehaviour {

	public int _playerNumber;
	public bool _pressed;

	void Start ()
	{
		_pressed = false;
		renderer.material.color = Color.red;
	}

	void OnTriggerEnter()
	{
		if (_pressed == false)
		{   
            renderer.enabled = true;
			renderer.material.color = Color.white;
		}
	}

	void OnTriggerStay()
	{

		switch (_playerNumber)
		{ 
		case 1:
			if (Input.GetAxis("A1") == 1)
			{
				_pressed = true;
				if (_pressed)
				{
					renderer.material.color = Color.green;
				}
			}
			
			break;
			
		case 2:
			if (Input.GetAxis("A2") == 1)
			{
				_pressed = true;
				if (_pressed)
				{
					renderer.material.color = Color.green;
				}
			}
			
			break;
			
		case 3:
			if (Input.GetAxis("A3") == 1)
			{
				_pressed = true;
				if (_pressed)
				{
					renderer.material.color = Color.green;
				}
			}
			
			break;
			
		case 4:
			if (Input.GetAxis("A4") == 1)
			{
				_pressed = true;
				if (_pressed)
				{
                    renderer.material.color = Color.green;
				}
			}
			
			break;
		}
	}

	void OnTriggerExit()
	{
		if (_pressed == false)
		{
			renderer.enabled = false;
		}
	}	
}
