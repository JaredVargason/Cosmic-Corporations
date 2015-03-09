using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour 
{
    public static int cardNumber;

	void Start ()
	{
		float x = BoardGameHandler._leftWorldBound;
		float y = BoardGameHandler._bottomWorldBound;

		GameObject sectorPrefab = (Resources.Load ("Sector")) as GameObject;
		GameObject sector;
		GameObject prefab;
		GameObject instance;

		Vector3 location;
		int numberOfInstances = 1;

		while (x < BoardGameHandler._rightWorldBound)
		{
			while (y < BoardGameHandler._topWorldBound)
			{
				location = new Vector3(x, y, 0);
				sector = Instantiate(sectorPrefab, location, sectorPrefab.transform.rotation) as GameObject;

				prefab = (Resources.Load("Card")) as GameObject;
				location = new Vector3(Random.Range(x, x + 50f), Random.Range(y, y + 50f), 0);
				instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
				instance.transform.parent = sector.transform;
				instance.SetActive(false);

				prefab = (Resources.Load("Coin1")) as GameObject;
				numberOfInstances = 8;
				while (numberOfInstances --> 0)
				{
					location = new Vector3(Random.Range(x, x + 50f), Random.Range (y, y + 50f), 0);
					instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
					instance.transform.parent = sector.transform;
					instance.SetActive(false);
				}
                
                prefab = (Resources.Load("Coin2")) as GameObject;
                numberOfInstances = 8;
                while (numberOfInstances --> 0)
                {
                    location = new Vector3(Random.Range(x, x + 50f), Random.Range (y, y + 50f), 0);
                    instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
                    instance.transform.parent = sector.transform;
                    instance.SetActive(false);
                }
                
                prefab = (Resources.Load("Coin3")) as GameObject;
                numberOfInstances = 6;
                while (numberOfInstances --> 0)
                {
                    location = new Vector3(Random.Range(x, x + 50f), Random.Range (y, y + 50f), 0);
                    instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
                    instance.transform.parent = sector.transform;
                    instance.SetActive(false);
                }
                
                if (y > 600)
                {
                    prefab = (Resources.Load("Coin4")) as GameObject;
                    numberOfInstances = 6;
                    while(numberOfInstances --> 0)
                    {
                        location = new Vector3(Random.Range(x, x + 50f), Random.Range (y, y + 50f), 0);
                        instance = Instantiate(prefab, location, prefab.transform.rotation) as GameObject;
                        instance.transform.parent = sector.transform;
                        instance.SetActive(false);
                    }
                }
                
				y += 50;

			}
			y = BoardGameHandler._bottomWorldBound;
			x += 50;
		}
	}
}
