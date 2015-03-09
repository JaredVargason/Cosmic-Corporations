using UnityEngine;
using System.Collections;

public class CartoonRocketBehavior : RocketBehavior
{ 
    //The cartoon rocket has the benefit of being able to turn off thrusters.
    //It moves in the direction it is facing.
    //It is affected normally by gravity.
    
    public ParticleSystem _fire;
    public ParticleSystem _smoke;
    public float _rotateSpeed = 2f;

    void OnEnable()
    {
        _smoke.enableEmission = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        float volume = coll.relativeVelocity.magnitude * velToVol;
        
        _source[1].pitch = Random.Range (pitchMin, pitchMax);
        
        int whichClip = (int)Random.Range (1f, 4.99f);
        switch (whichClip)
        {
            case 1:
                _source[1].PlayOneShot(_collision1, volume);
                break;
                
            case 2:
                _source[1].PlayOneShot(_collision2, volume);
                break;
                
            case 3:
                _source[1].PlayOneShot(_collision3, volume);
                break;
                
            case 4:
                _source[1].PlayOneShot(_collision4, volume);
                break;
        }
        
        if (coll.collider.tag == "Terrain")
        {
            
            if (rigidbody.velocity.magnitude > 1.5f)
            {
                Vector3 tempVelocity = rigidbody.velocity;
                Material tempMaterial = transform.GetChild(0).renderer.material;
                rigidbody.isKinematic = true;
                
                foreach(Transform child in transform)
                {
                    if (child.GetComponent<Collider>() != null)
                    {
                        child.collider.enabled = false;
                    }

                    if (child.GetComponent<Renderer>() != false)
                    {
                        child.renderer.enabled = false;
                    }
                }

                GameObject debris = Resources.Load("rocket_debris") as GameObject;
                debris = Instantiate(debris, transform.position, transform.rotation) as GameObject;


                foreach (Transform child in debris.transform)
                {
                    child.rigidbody.velocity = tempVelocity;
                    child.renderer.material = tempMaterial;
                }
            }

            _source[0].Stop();
            _fire.enableEmission = false;

            if (_timer._roundTimer > 2)
            {
                this.enabled = false;
            }
        }
    }
    
    public override void position ()
    {
        if (horizontal != 0) 
        {
            rigidbody.AddTorque(horizontal * Vector3.forward * _rotateSpeed);
            
            if (transform.position.y < 1) 
            {
                _fuel -= 2;
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
    
    public override void accelerate()
    {
        if (_fuel > 0 && thrustersOn)
        {
            rigidbody.AddForce(transform.up * _speed * rigidbody.mass);
            _fuel -= Time.deltaTime;
            _fire.enableEmission = true;
            
            if (!_source[0].isPlaying)
            {
                _source[0].Play();
            }
        }
        
        if (thrustersOn == false) 
        {
            _fire.enableEmission = false;
            _source[0].Pause();
        }
        
        if (_fuel <= 0)
        {
            _fire.enableEmission = false;
            _source[0].Pause();
            
            if (rigidbody.velocity.y < 0)
            {
                rigidbody.drag = .1f;
            }
        }
    }
    
    public override void shootMissle()
    {
        if (shotMissle && _hasMissle == true)
        {
            GameObject prefab = Resources.Load("misslePrefab") as GameObject;
            GameObject missleInstance = Instantiate(prefab, transform.GetChild(0).position, transform.rotation) as GameObject;
            
            foreach (Transform child in transform)
            {
                if (child.collider != null && missleInstance.collider != child.collider)
                {
                    Physics.IgnoreCollision(missleInstance.collider, child.collider);
                }
            }
            
            missleInstance.transform.parent = transform;
            gameObject.animation.Play();
            _hasMissle = false;
        }
    }
}
