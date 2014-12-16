using UnityEngine;
using System.Collections;

public class CoinBehavior : MonoBehaviour {

	public int _coinValue;
	private int _rotateDirection;

	void Start () 
	{
		_coinValue = ObjectSpawner.value;
		_rotateDirection = Random.Range (0, 2); //returns float between 0 and 2 and truncates.
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (renderer.isVisible)
		{
			if (_rotateDirection == 0)
			{
				transform.Rotate (0, 1 * Time.timeScale, 0);
			}
		
			if (_rotateDirection == 1)
			{
				transform.Rotate (0, -1 * Time.timeScale, 0);
			}
		}
	}


	void OnTriggerEnter(Collider other) 
	{
		if (other.transform.tag == "Player") 
		{

			switch (other.transform.parent.GetComponent<RocketBehavior>()._playerNumber)
			{
			case 1:

				break;
			case 2:

				break;
			case 3:

				break;
			case 4: 

				break;
			}
			Destroy(gameObject);
		}
	}
}