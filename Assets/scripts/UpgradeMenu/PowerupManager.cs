using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour 
{
	/*public int _powerupNumber;
	public TextMesh _textCost;
	public TextMesh _textValue;
	public bool _bought = false;
	public float _cost;
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
		if (BoardGameHandler._hasMissle1)
		{	
			_bought = true;
		}
		
		if (!BoardGameHandler._hasMissle1 && _cost > BoardGameHandler._totalMoney1) 
		{
			gameObject.transform.renderer.material = _unavailableMaterial;
		}
		
		else if (BoardGameHandler._totalMoney1 >= _cost && _bought == false && _triggered == true) 
		{
			gameObject.transform.renderer.material = _cursorMaterial;
			
			if (Input.GetAxis("A1") == 1) 
			{
				_bought = true;
				BoardGameHandler._totalMoney1 -= _cost;
				BoardGameHandler._hasMissle1 = true;
			}
		}
		
		else if (BoardGameHandler._totalMoney1 >= _cost && _bought == false && _triggered == false) 
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
		_textValue.text = "1 Missle";
	}
	
	void OnTriggerExit(Collider other)
	{
		_triggered = false;
	}*/
	
}
