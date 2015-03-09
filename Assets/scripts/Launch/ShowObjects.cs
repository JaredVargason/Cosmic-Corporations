using UnityEngine;
using System.Collections;

public class ShowObjects : MonoBehaviour {

	public int _numberTriggered;

	void Awake()
	{
		_numberTriggered = 0;
	}

	void OnTriggerEnter(Collider coll)
	{

		if (coll.transform.tag == "Player")
		{
			_numberTriggered += 1;
            
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
		}
	}

	void OnTriggerStay()
	{

	}

	void OnTriggerExit(Collider coll)
	{
		
		if (coll.transform.tag == "Player")
		{
			_numberTriggered -= 1;
		}

		if (_numberTriggered == 0)
		{
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive(false);
			}
		}

	}
}
