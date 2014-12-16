using UnityEngine;
using System.Collections;

public class CardBehavior : MonoBehaviour 
{

	private int _rotateDirection;

	// Use this for initialization
	void Start () 
	{
		_rotateDirection = Random.Range (0, 2); //returns float between 0 and 2 and truncates.
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (renderer.isVisible)
		{
			if (_rotateDirection == 0)
			{
				transform.Rotate (0, 0, 1);
			}

			if (_rotateDirection == 1)
			{
				transform.Rotate (0, 0, -1);
			}
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.transform.tag == "Player") 
		{
			switch (other.transform.parent.GetComponent<RocketBehavior> ()._playerNumber) 
			{
			case 1:
					BoardGameHandler._numberOfCards1++;
					break;
			case 2:
					BoardGameHandler._numberOfCards2++;
					break;
			case 3:
					BoardGameHandler._numberOfCards3++;
					break;
			case 4: 
					BoardGameHandler._numberOfCards4++;
					break;
			}

			Destroy (gameObject);
		}
	}
}
