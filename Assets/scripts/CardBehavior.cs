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
			other.transform.parent.GetComponent<RocketInfo>()._cardsCollected += 1;

			Destroy (gameObject);
		}
	}
}
