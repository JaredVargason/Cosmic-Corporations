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
				transform.Rotate (0, 0, 100 * Time.deltaTime);
			}

			if (_rotateDirection == 1)
			{
				transform.Rotate (0, 0, 100 * Time.deltaTime);
			}
		}
	}

	void OnCollisionEnter(Collision collision) 
	{
        if (collision.collider.tag == "Terrain") //Pushes object up if it collides with the terrain. Might be wiser to destroy it.
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            
            transform.position = new Vector3(x, y + Random.Range(.5f, .99f), z);
        }
	}
}
