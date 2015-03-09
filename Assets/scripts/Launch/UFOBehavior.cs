using UnityEngine;
using System.Collections;

public class UFOBehavior : RocketBehavior {
    
    //The UFO has the benefit of being able to add force in any direction.
    //It can press A alone to sit still in the air at the cost of fuel.
    //It is affected by gravity normally.
    //Fuel usage can be turned on and off normally.
    //Lower mass than other rockets allows it to be hit around more easily.
    //Auto stabilization system.
    
    public override void accelerate()
    {
        if (_fuel > 0 && thrustersOn)
        {
            if (vertical != 0 || horizontal != 0)
            {
                rigidbody.AddForce(transform.up * vertical * _speed * rigidbody.mass);
                rigidbody.AddForce(transform.right * -horizontal * _speed * rigidbody.mass);
                //rigidbody.AddForce(new Vector3(-horizontal, vertical, 0) * _speed * rigidbody.mass);
            }
            
            else //(vertical == 0 && horizontal == 0)
            {
                rigidbody.AddForce(-Physics.gravity);
                rigidbody.AddForce(-rigidbody.velocity);
            }
            
            _fuel -= Time.deltaTime;
            
            if (!_source[0].isPlaying)
            {
                _source[0].Play();
            }
        }
        
        if (thrustersOn == false) 
        {
            _source[0].Pause();
        }
        
        if (_fuel <= 0)
        {
            _source[0].Pause();
            
            if (rigidbody.velocity.y < 0)
            {
                rigidbody.drag = .1f;
            }
        }
    }
    
    public override void position()
    {
        if (_fuel > 0)
        {
            if (transform.rotation.eulerAngles.z != 0)
            {
                if (transform.rotation.eulerAngles.z < 355 && transform.rotation.eulerAngles.z > 180)
                {
                    rigidbody.AddTorque(new Vector3(0, 0, 1));
                }
                
                else if (transform.rotation.eulerAngles.z > 5 && transform.rotation.eulerAngles.z < 180)
                {
                    rigidbody.AddTorque(new Vector3(0, 0, -1)); 
                }
            }
            
            else if (rigidbody.angularVelocity.z != 0 && rigidbody.rotation.eulerAngles.z == 0)
            {
                rigidbody.angularVelocity = new Vector3(0, 0, 0);
            }
        }
        
        foreach (Transform child in transform)
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                child.transform.Rotate(transform.forward * rigidbody.velocity.x/3);
                //if (transform.rotation.eulerAngles.x != 0)
                //{
                //     transform.rotation.eulerAngles.Set(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                // }
            }
        }
    }
    
    public override void shootMissle()
    {
        
    }
}
