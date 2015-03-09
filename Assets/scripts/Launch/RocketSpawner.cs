using UnityEngine;
using System.Collections;

public class RocketSpawner : MonoBehaviour {

	//possibly combine this with random rocket positions. probably not though.
    //Script needs to instantiate the prefab for the rocket and then change its material.
    
    void Awake()
    {
        for (int i = 1; i <= PlayMenu._numberOfPlayers; i++)
        {
            GameObject prefab;
            GameObject instance = null;
            
            if (BoardGameHandler._rocketType[i - 1] == 0)
            {
                prefab = Resources.Load("Rocket") as GameObject;
                instance = GameObject.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
            }
            
            if (BoardGameHandler._rocketType[i - 1] == 1)
            {
                prefab = Resources.Load("UFO") as GameObject;
            }
            
            if (BoardGameHandler._rocketType[i - 1] == 2)
            {
                
            }
            
            if (BoardGameHandler._rocketType[i - 1] == 3)
            {
                
            }
            
            RocketBehavior rocket = instance.GetComponent<RocketBehavior>();
            rocket._playerNumber = i;
            
        }
    }
}
