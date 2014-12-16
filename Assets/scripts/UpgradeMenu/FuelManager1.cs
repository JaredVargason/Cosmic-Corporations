using UnityEngine;
using System.Collections;

public class FuelManager1 : MonoBehaviour 
{
	public int _playerNumber;
    public float _playerFuel;
	public float _playerMoney;
	public TextMesh _textCost;
	public TextMesh _textValue;
	public TextMesh _textCurrent;
	public TextMesh _textMoney;
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

		switch (_playerNumber)
		{
			case 1:
				pressed = Input.GetAxis("Thrust Ship 1");
				_playerFuel = BoardGameHandler._fuel1;
				_playerMoney = BoardGameHandler._totalMoney1;
				break;

			case 2:
				pressed = Input.GetAxis("Thrust Ship 2");
				_playerFuel = BoardGameHandler._fuel2;
				_playerMoney = BoardGameHandler._totalMoney2;
				break;

			case 3:
				pressed = Input.GetAxis("Thrust Ship 3");
				_playerFuel = BoardGameHandler._fuel3;
				_playerMoney = BoardGameHandler._totalMoney3;
				break;

			case 4:
				pressed = Input.GetAxis("Thrust Ship 4");
				_playerFuel = BoardGameHandler._fuel4;
				_playerMoney = BoardGameHandler._totalMoney4;
				break;
		}

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

				switch (_playerNumber) //updates static variable on buy
				{
					case 1:
						BoardGameHandler._totalMoney1 = _playerMoney;
						BoardGameHandler._fuel1 = _playerFuel;
						break;

					case 2:
						BoardGameHandler._totalMoney2 = _playerMoney;
						BoardGameHandler._fuel2 = _playerFuel;
						break;

					case 3:
						BoardGameHandler._totalMoney3 = _playerMoney;
						BoardGameHandler._fuel3 = _playerFuel;
						break;

					case 4:
						BoardGameHandler._totalMoney4 = _playerMoney;
						BoardGameHandler._fuel4 = _playerFuel;
						break;
				}
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
		_textCurrent.renderer.enabled = true;
		_textMoney.renderer.enabled = true;
		
		_textCost.text = "Cost: $" + _cost;
		_textValue.text = "Fuel: " + _fuelValue;
		_textCurrent.text = "Current: " + _playerFuel;
		_textMoney.text = "Money: $" + _playerMoney;
	}

	void OnTriggerExit(Collider other)
	{
		_triggered = false;
	}

}
