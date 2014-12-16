using UnityEngine;
using System.Collections;

public class SelectorBehavior : MonoBehaviour 
{

	private int _speed = 7;
	public GameObject _selector1, _selector2, _selector3, _selector4;
	
	void Start () 
	{
	
	}

	void Update () 
	{
		if (Input.GetAxis("Rotate Ship 1") != 0 || Input.GetAxis ("Vertical 1") != 0) 
		{
			float x = Input.GetAxis("Rotate Ship 1");
			float y = Input.GetAxis("Vertical 1");
			_selector1.transform.Translate(new Vector3(x, y, 0f) * Time.deltaTime * _speed);
		}

		if (Input.GetAxis("Rotate Ship 2") != 0 || Input.GetAxis ("Vertical 2") != 0) 
		{
			float x = Input.GetAxis("Rotate Ship 2");
			float y = Input.GetAxis("Vertical 2");
			_selector2.transform.Translate(new Vector3(x, y, 0f) * Time.deltaTime * _speed);
		}
		
		if (Input.GetAxis("Rotate Ship 3") != 0 || Input.GetAxis ("Vertical 3") != 0) 
		{
			float x = Input.GetAxis("Rotate Ship 3");
			float y = Input.GetAxis("Vertical 3");
			_selector3.transform.Translate(new Vector3(x, y, 0f) * Time.deltaTime * _speed);
		}
		
		if (Input.GetAxis("Rotate Ship 4") != 0 || Input.GetAxis ("Vertical 4") != 0) 
		{
			float x = Input.GetAxis("Rotate Ship 4");
			float y = Input.GetAxis("Vertical 4");
			_selector4.transform.Translate(new Vector3(x, y, 0f) * Time.deltaTime * _speed);
		}
	}
}
