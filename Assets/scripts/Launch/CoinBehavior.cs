using UnityEngine;
using System.Collections;

public class CoinBehavior : MonoBehaviour {

	public int _coinValue;
	private int _rotateDirection;
	

	void Awake () 
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
				transform.Rotate (0, 150 * Time.deltaTime, 0);
			}
		
			if (_rotateDirection == 1)
			{
				transform.Rotate (0, -150 * Time.deltaTime, 0);
			}
		}
	}


	void OnCollisionEnter(Collision other) 
	{
		/*if (other.transform.tag == "Player" && _roundTimer._roundTimer > 0) //if a player hits the coin after round starts
		{
			_source.PlayOneShot(_clip, 1f);
			other.transform.parent.GetComponent<RocketInfo>()._money += _coinValue;

			renderer.enabled = false;
			collider.enabled = false;

			StartCoroutine(killem());
		}
        
        else if (other.transform.tag == "Player" && _roundTimer._roundTimer < 0) //if coin spawns on player it moves up and possibly to the left or right so rocket does not automatically collect it
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            
            transform.position = new Vector3(x + Random.Range(-2f, 2f), y + Random.Range(.1f, 1.99f), z);
        }*/
        
        if (other.collider.tag == "Terrain") //if a coin spawns in contact with terrain it is moved up
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            
            transform.position = new Vector3(x, y + Random.Range(.5f, .99f), z);
        }
	}
}