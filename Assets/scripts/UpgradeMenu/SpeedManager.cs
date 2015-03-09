using UnityEngine;
using System.Collections;

public class SpeedManager : MonoBehaviour 
{
	public int _playerNumber;
	public float _playerSpeed;
	public float _playerMoney;
	public TextMesh _textCost;
	public TextMesh _textValue;
	public bool _bought = false;
	public float _cost;
	public float _speedValue;
	public Material _availableMaterial;
	public Material _unavailableMaterial;
	public Material _boughtMaterial;
	public Material _cursorMaterial;
	
	public bool _triggered = false;
    
	void Awake() 
	{

	}
	
	void Start () 
	{

	}
	
	void Update () 
	{
        
		float pressed = 0f;
        
        pressed = Input.GetAxis("A" + _playerNumber);
        _playerSpeed = BoardGameHandler._speed[_playerNumber - 1];
        _playerMoney = BoardGameHandler._totalMoney[_playerNumber - 1];
		
		if (_playerSpeed >= _speedValue)
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
				_playerSpeed = _speedValue;

                BoardGameHandler._totalMoney[_playerNumber - 1] = _playerMoney;
                BoardGameHandler._speed[_playerNumber - 1] = _playerMoney;
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
		
		_textCost.text = "$" + _cost;
		_textValue.text = "Speed: " + _speedValue;
	}
	
	void OnTriggerExit(Collider other)
	{
		_triggered = false;
	}
	
}
