using UnityEngine;
using System.Collections;

public class DragManager : MonoBehaviour 
{
	public int _playerNumber;
	public float _playerDrag;
	public float _playerMoney;
	public TextMesh _textCost;
	public TextMesh _textValue;
	public bool _bought = false;
	public float _cost;
	public float _dragValue;
	public float _angularDragValue;
	public Material _availableMaterial;
	public Material _unavailableMaterial;
	public Material _boughtMaterial;
	public Material _cursorMaterial;
	
	public bool _triggered = false;
	
	void Update () 
	{
		float pressed = 0f;
		
        _playerDrag = BoardGameHandler._drag[_playerNumber - 1];
        _playerMoney = BoardGameHandler._totalMoney[_playerNumber - 1];
		
		if (_playerDrag <= _dragValue)
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
				_playerDrag = _dragValue;
				
                BoardGameHandler._totalMoney[_playerNumber - 1] = _playerMoney;
                BoardGameHandler._drag[_playerNumber - 1] = _playerDrag;
                BoardGameHandler._angularDrag[_playerNumber - 1] = _angularDragValue;
				
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
		_textValue.text = "Drag: " + _dragValue;
	}
	
	void OnTriggerExit(Collider other)
	{
		_triggered = false;
	}
	
}
