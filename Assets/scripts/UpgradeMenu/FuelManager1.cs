using UnityEngine;
using System.Collections;

public class FuelManager1 : MonoBehaviour 
{
	public int _playerNumber;
    public float _playerFuel;
	public float _playerMoney;
	public TextMesh _textCost;
	public TextMesh _textValue;
	public bool _bought = false;
	public float _cost;
	public float _fuelValue;
	public Material _availableMaterial;
	public Material _unavailableMaterial;
	public Material _boughtMaterial;
	public Material _cursorMaterial;

	public bool _triggered = false;

	void Update () 
	{
		float pressed = 0f;
        
        pressed = Input.GetAxis("A" + _playerNumber);
        _playerFuel = BoardGameHandler._fuel[_playerNumber - 1];
        _playerMoney = BoardGameHandler._totalMoney[_playerNumber - 1];
        
		/*switch (_playerNumber)

            pressed = Input.GetAxis("A" + _playerNumber);
            
			case 1:
				pressed = Input.GetAxis("A1");
				_playerFuel = BoardGameHandler._fuel1;
				_playerMoney = BoardGameHandler._totalMoney1;
				break;

			case 2:
				pressed = Input.GetAxis("A2");
				_playerFuel = BoardGameHandler._fuel2;
				_playerMoney = BoardGameHandler._totalMoney2;
				break;

			case 3:
				pressed = Input.GetAxis("A3");
				_playerFuel = BoardGameHandler._fuel3;
				_playerMoney = BoardGameHandler._totalMoney3;
				break;

			case 4:
				pressed = Input.GetAxis("A4");
				_playerFuel = BoardGameHandler._fuel4;
				_playerMoney = BoardGameHandler._totalMoney4;
				break;
		}*/

		if (_playerFuel >= _fuelValue)
		{	
			_bought = true;
		}

		if (_playerMoney < _cost && _bought == false) 
		{
			gameObject.transform.renderer.material = _unavailableMaterial;
		}

		else if (_playerMoney >= _cost && _bought == false && _triggered == true) 
		{
			gameObject.transform.renderer.material = _cursorMaterial;
			
			if (pressed == 1) 
			{
				_bought = true;
				_playerMoney -= _cost;
				_playerFuel = _fuelValue;
                
                BoardGameHandler._totalMoney[_playerNumber - 1] = _playerMoney;
                BoardGameHandler._fuel[_playerNumber - 1] = _playerFuel;
			}
		}

		else if (_playerMoney >= _cost && _bought == false && _triggered == false) 
		{
			gameObject.transform.renderer.material = _availableMaterial;
		}

		else if (_bought == true) 
		{
			gameObject.transform.renderer.material = _boughtMaterial;
		}
	}	

	void OnTriggerEnter(Collider other)
	{
		_triggered = true;
	}

	void OnTriggerStay(Collider other) 
	{
		_textCost.renderer.enabled = true;
		_textValue.renderer.enabled = true;
		
		_textCost.text = "Cost: $" + _cost;
		_textValue.text = "Fuel: " + _fuelValue;
	}

	void OnTriggerExit(Collider other)
	{
		_triggered = false;
	}

}
