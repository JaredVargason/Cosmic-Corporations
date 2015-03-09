using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomRocketPosition : MonoBehaviour {
    
    private List<float> startingPositions = new List<float>();
    public RocketBehavior[] _rockets = new RocketBehavior[4];
    
	void Start ()
    {
    
        switch (PlayMenu._numberOfPlayers)
        {
            case 1:
                startingPositions.Add(0f);
                break;
                
            case 2:
                startingPositions.Add(-1f);
                startingPositions.Add(1f);
                break;
                
            case 3:
                startingPositions.Add(-2f);
                startingPositions.Add(0f);
                startingPositions.Add(2f);
                break;
                
           case 4:
                startingPositions.Add(-3f);
                startingPositions.Add(-1f);
                startingPositions.Add(1f);
                startingPositions.Add(3f);
                break;
        }
        
        for (int i = 0; i < PlayMenu._numberOfPlayers; i++)
        {
            RocketBehavior rocket = _rockets[i];
            int rand = Random.Range(0, startingPositions.Count);
            rocket.transform.position = new Vector3(startingPositions[rand], 0.1f, 0);
            startingPositions.RemoveAt(rand);
        }
	}
}
