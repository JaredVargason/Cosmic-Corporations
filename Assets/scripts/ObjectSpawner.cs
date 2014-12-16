using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour 
{
	public static int value;

	void Start () 
	{
		GameObject prefab;
		GameObject instance;
		Vector3 location;

		prefab = (Resources.Load("Card")) as GameObject;
		int numberOfInstances = Random.Range(700, 800);
		while (numberOfInstances --> 0) 
		{
			location = new Vector3 (Random.Range ((float)BoardGameHandler._leftWorldBound, (float)BoardGameHandler._rightWorldBound),
			                        Random.Range ((float)BoardGameHandler._bottomWorldBound + 3f, BoardGameHandler._topWorldBound - 2f), 0);

			instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
		}

		//spawns for coin values
		value = 1;
		prefab = (Resources.Load ("Coin1")) as GameObject;
		numberOfInstances = Random.Range (6000, 6500);
		while (numberOfInstances --> 0) 
		{
			location = new Vector3 (Random.Range ((float)BoardGameHandler._leftWorldBound, (float)BoardGameHandler._rightWorldBound),
			                        Random.Range ((float)BoardGameHandler._bottomWorldBound + 2f, BoardGameHandler._topWorldBound - 2f), 0);

			instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
		}

		/*value = 2;
		prefab = (Resources.Load ("Coin2")) as GameObject;
		numberOfInstances = Random.Range (300, 400);
		while (numberOfInstances --> 0) 
		{
			location = new Vector3 (Random.Range ((float)BoardGameHandler._leftWorldBound, (float)BoardGameHandler._rightWorldBound),
			                        Random.Range ((float)BoardGameHandler._bottomWorldBound + 5f, 10f), 0);
			
			instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
		}

		value = 5;
		prefab = (Resources.Load ("Coin3")) as GameObject;
		numberOfInstances = Random.Range (300, 400);
		while (numberOfInstances --> 0) 
		{
			location = new Vector3 (Random.Range ((float)BoardGameHandler._leftWorldBound, (float)BoardGameHandler._rightWorldBound),
			                        Random.Range ((float)BoardGameHandler._bottomWorldBound + 5f, 10f), 0);
			
			instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
		}

		value = 10;
		prefab = (Resources.Load ("Coin4")) as GameObject;
		numberOfInstances = Random.Range (300, 400);
		while (numberOfInstances --> 0) 
		{
			location = new Vector3 (Random.Range ((float)BoardGameHandler._leftWorldBound, (float)BoardGameHandler._rightWorldBound),
			                        Random.Range ((float)BoardGameHandler._bottomWorldBound + 5f, 10f), 0);
			
			instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
		}*/
	}
}
