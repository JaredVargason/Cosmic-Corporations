using UnityEngine;
using System.Collections;

public class MagnetMovement : MonoBehaviour {

	private float _rotateSpeed = 10f;
    
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetAxis("") != 0)
        {
            transform.RotateAround(transform.parent.position, Vector3.forward, Input.GetAxis("") * Time.deltaTime * _rotateSpeed);
        }
	}
}
